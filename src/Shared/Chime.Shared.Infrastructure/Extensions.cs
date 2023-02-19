using System.Reflection;
using System.Runtime.CompilerServices;
using Chime.Shared.Abstractions.Dispatchers;
using Chime.Shared.Abstractions.Time;
using Chime.Shared.Infrastructure.API;
using Chime.Shared.Infrastructure.Commands;
using Chime.Shared.Infrastructure.Contexts;
using Chime.Shared.Infrastructure.Dispatchers;
using Chime.Shared.Infrastructure.Postgres;
using Chime.Shared.Infrastructure.Queries;
using Chime.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Shared.Infrastructure;

internal static class Extensions
{
    private const string CorrelationIdKey = "correlation-id";

    public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
    {
        return services.AddTransient<IInitializer, T>();
    }

    public static IServiceCollection AddModularInfrastructure(this IServiceCollection services,
        IList<Assembly> assemblies)
    {
        var disabledModules = new List<string>();
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled")) continue;

                if (!bool.Parse(value)) disabledModules.Add(key.Split(":")[0]);
            }
        }

        services
            .AddContext()
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddSingleton<IDispatcher, InMemoryDispatcher>()
            .AddPostgres()
            .AddSingleton<IClock, UtcClock>()
            .AddHostedService<DbContextAppInitializer>()
            .AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                var removedParts = new List<ApplicationPart>();
                foreach (var disabledModule in disabledModules)
                {
                    var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                        StringComparison.InvariantCultureIgnoreCase));
                    removedParts.AddRange(parts);
                }

                foreach (var part in removedParts) manager.ApplicationParts.Remove(part);
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });

        return services;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }

    public static string GetModuleName(this object value)
    {
        return value?.GetType().GetModuleName() ?? string.Empty;
    }

    public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
    {
        if (type?.Namespace is null) return string.Empty;

        return type.Namespace.Contains(namespacePart)
            ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
            : string.Empty;
    }

    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
    {
        return app.Use((ctx, next) =>
        {
            ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
            return next();
        });
    }

    public static Guid? TryGetCorrelationId(this HttpContext context)
    {
        return context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;
    }
}