using Chime.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Modules.Customers.Api;

internal class CustomersModule: IModule
{
    public string Name { get; } = "Customers";
    
    public void Register(IServiceCollection serviceCollection)
    {
        throw new NotImplementedException();
    }

    public void Use(IApplicationBuilder app)
    {
        throw new NotImplementedException();
    }
}