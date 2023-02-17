using System.Runtime.CompilerServices;
using Chime.Modules.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]


namespace Chime.Modules.Customers.Api;

internal static class Extensions
{
    public static IServiceCollection AddCustomersModule(this IServiceCollection services)
    {
        services.AddCore();
        return services;
    }

    public static IApplicationBuilder UseCustomersModule(this IApplicationBuilder builder)
    {
        return builder;
    }
}