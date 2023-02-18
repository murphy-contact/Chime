using System.ComponentModel.Design;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    void Register(IServiceCollection serviceCollection);
    void Use(IApplicationBuilder app);
}