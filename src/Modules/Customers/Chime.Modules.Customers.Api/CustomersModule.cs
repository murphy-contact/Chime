using System.Runtime.CompilerServices;
using Chime.Modules.Customers.Core;
using Chime.Modules.Customers.Core.Events.External.SignedUp;
using Chime.Shared.Abstractions.Modules;
using Chime.Shared.Infrastructure.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Modules.Customers.Api;

internal class CustomersModule : IModule
{
    public string Name { get; } = "Customers";

    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
        app.UseContracts().Register<SignedUpContract>();
    }
}