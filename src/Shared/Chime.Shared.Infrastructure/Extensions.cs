using System.Runtime.CompilerServices;
using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Time;
using Chime.Shared.Infrastructure.Commands;
using Chime.Shared.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModularInfrastructure(this IServiceCollection services)
    {
        services
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IClock, UtcClock>();
        return services;
    }
}