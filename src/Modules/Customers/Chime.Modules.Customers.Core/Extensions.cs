using System.Runtime.CompilerServices;
using Chime.Modules.Customers.Core.Clients.UserApiClient;
using Chime.Modules.Customers.Core.DAL;
using Chime.Modules.Customers.Core.DAL.Repositories;
using Chime.Modules.Customers.Core.Domain.Repositories;
using Chime.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Chime.Modules.Customers.Api")]

namespace Chime.Modules.Customers.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUserApiClient, UserApiClient>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddPostgres<CustomersDbContext>();
        services.AddUnitOfWork<CustomersUnitOfWork>();

        return services;
    }
}