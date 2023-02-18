using System.Reflection;
using System.Runtime.CompilerServices;
using Chime.Shared.Abstractions.Dispatchers;
using Chime.Shared.Abstractions.Time;
using Chime.Shared.Infrastructure.Commands;
using Chime.Shared.Infrastructure.Dispatchers;
using Chime.Shared.Infrastructure.Postgres;
using Chime.Shared.Infrastructure.Queries;
using Chime.Shared.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModularInfrastructure(this IServiceCollection services,
        IList<Assembly> assemblies)
    {
        services
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddSingleton<IDispatcher, InMemoryDispatcher>()
            .AddPostgres()
            .AddSingleton<IClock, UtcClock>();
        // .AddControllers()
        // .ConfigureApplicationPartManager();

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
}