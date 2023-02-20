using System.Reflection;
using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chime.Shared.Infrastructure.Modules;

public static class Extensions
{
    internal static IHostBuilder ConfigureModules(this IHostBuilder builder)
    {
        return builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            var enumerable = GetSettings("*");
            foreach (var settings in enumerable)
                cfg.AddJsonFile(settings);

            IEnumerable<string> GetSettings(string pattern)
            {
                return Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                    $"modules.{pattern}.json", SearchOption.AllDirectories);
            }
        });
    }

    internal static IServiceCollection AddModuleRequests(this IServiceCollection services, IList<Assembly> assemblies)
    {
        // services.AddModuleRegistry(assemblies);
        // services.AddSingleton<IModuleClient, ModuleClient>();
        services.AddSingleton<IModuleRegistry, ModuleRegistry>();
        services.AddSingleton<IModuleSubscriber, ModuleSubscriber>();
        // services.AddSingleton<IModuleSerializer, JsonModuleSerializer>();
        // services.AddSingleton<IModuleSerializer, MessagePackModuleSerializer>();

        return services;
    }


    public static IModuleSubscriber UseModuleRequests(this IApplicationBuilder app)
    {
        return app.ApplicationServices.GetRequiredService<IModuleSubscriber>();
    }


    private static void AddModuleRegistry(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        var registry = new ModuleRegistry();
        var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();

        var commandTypes = types
            .Where(t => t.IsClass && typeof(ICommand).IsAssignableFrom(t))
            .ToArray();

        // var eventTypes = types
        //     .Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x))
        //     .ToArray();

        services.AddSingleton<IModuleRegistry>(sp =>
        {
            var commandDispatcher = sp.GetRequiredService<ICommandDispatcher>();
            var commandDispatcherType = commandDispatcher.GetType();

            // var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
            // var eventDispatcherType = eventDispatcher.GetType();

            foreach (var type in commandTypes)
                registry.AddBroadcastAction(type, (@event, cancellationToken) =>
                    (Task)commandDispatcherType.GetMethod(nameof(commandDispatcher.SendAsync))
                        ?.MakeGenericMethod(type)
                        .Invoke(commandDispatcher, new[] { @event, cancellationToken }));

            // foreach (var type in eventTypes)
            // {
            //     registry.AddBroadcastAction(type, (@event, cancellationToken) =>
            //         (Task) eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))
            //             ?.MakeGenericMethod(type)
            //             .Invoke(eventDispatcher, new[] {@event, cancellationToken}));
            // }

            return registry;
        });
    }
}