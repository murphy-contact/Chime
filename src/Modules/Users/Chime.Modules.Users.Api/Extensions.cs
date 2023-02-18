using System.Runtime.CompilerServices;
using Chime.Modules.Users.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Chime.Bootstrapper")]
namespace Chime.Modules.Users.Api;

internal static class Extensions
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddCore();
        return services;
    }

    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder builder)
    {
        return builder;
    }
}