using System.Runtime.CompilerServices;
using Chime.Modules.Users.Core.DAL;
using Chime.Modules.Users.Core.DAL.Repositories;
using Chime.Modules.Users.Core.Domain.Entities;
using Chime.Modules.Users.Core.Repositories;
using Chime.Shared.Infrastructure;
using Chime.Shared.Infrastructure.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Modules.Users.Api")]

namespace Chime.Modules.Users.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddPostgres<UsersDbContext>()
            .AddUnitOfWork<UsersUnitOfWork>()
            .AddInitializer<UsersInitializer>();
    }

    private static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
    {
        return services.AddTransient<IInitializer, T>();
    }
}