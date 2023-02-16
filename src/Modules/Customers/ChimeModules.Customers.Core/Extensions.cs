using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Modules.Customers.Api")]

namespace ChimeModules.Customers.Core;

public static class Extensions
{
    
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
   
}