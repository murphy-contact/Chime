using Chime.Shared.Infrastructure.Postgres;

namespace Chime.Modules.Customers.Core.DAL;

internal class CustomersUnitOfWork : PostgresUnitOfWork<CustomersDbContext>
{
    public CustomersUnitOfWork(CustomersDbContext dbContext) : base(dbContext)
    {
    }
}