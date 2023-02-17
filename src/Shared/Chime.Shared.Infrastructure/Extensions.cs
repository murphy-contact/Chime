using System.Runtime.CompilerServices;
using Chime.Shared.Abstractions.Time;
using Chime.Shared.Infrastructure.Commands;
using Chime.Shared.Infrastructure.Postgres;
using Chime.Shared.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModularInfrastructure(this IServiceCollection services)
    {
        services
            .AddCommands()
            .AddPostgres()
            .AddSingleton<IClock, UtcClock>();
        // .AddControllers()
        // .ConfigureApplicationPartManager();

        return services;
    }

    // public static IMvcBuilder AddControllers(this IServiceCollection services)
    // {
    //     // if (services == null)
    //     // {
    //     //     throw new ArgumentNullException(nameof(services));
    //     // }
    //     //
    //     // var builder = AddControllersCore(services);
    //     // return new MvcBuilder(builder.Services, builder.PartManager);
    //     services
    //         .AddControllers()
    //         .ConfigureApplicationPartManager(manager =>
    //         {
    //
    //         });
    //
    //     var builder = AddControllersCore(services);
    //     return new MvcBuilder(builder.Services, builder.PartManager);
    //
    // }

    // private static IMvcCoreBuilder AddControllersCore(IServiceCollection services)
    // {
    //     // This method excludes all of the view-related services by default.
    //     var builder = services
    //         .AddMvcCore()
    //         .AddApiExplorer()
    //         .AddAuthorization()
    //         .AddCors()
    //         .AddDataAnnotations()
    //         .AddFormatterMappings();
    //
    //     if (MetadataUpdater.IsSupported)
    //     {
    //         services.TryAddEnumerable(
    //             ServiceDescriptor.Singleton<IActionDescriptorChangeProvider, HotReloadService>());
    //     }
    //
    //     return builder;
    // }

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