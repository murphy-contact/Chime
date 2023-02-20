using System.Runtime.CompilerServices;
using Chime.Modules.Users.Core;
using Chime.Modules.Users.Core.Queries.GetUserByEmail;
using Chime.Shared.Abstractions.Modules;
using Chime.Shared.Abstractions.Queries;
using Chime.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Modules.Users.Api;

internal class UsersModule : IModule
{
    public string Name { get; } = "Users";

    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
        app.UseModuleRequests()
            .Subscribe<GetUserByEmail, GetUserByEmailResponseModel>("users/get-by-email",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
    }
}