using Chime.Modules.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Modules.Customers.Api;

public static class Extensions
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