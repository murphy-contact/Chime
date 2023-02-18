using Chime.Modules.Customers.Core.DAL;
using Chime.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Chime.Modules.Customers.Core.Queries.GetCustomer;

internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDetailsDto>
{
    private readonly CustomersDbContext _dbContext;

    // Read-models and queries 18
    public GetCustomerHandler(CustomersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerDetailsDto> HandleAsync(GetCustomer query, CancellationToken cancellationToken = default)
    {
        var customer = await _dbContext.Customers
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == query.CustomerId, cancellationToken);

        return customer?.AsResponseModel();
    }
}