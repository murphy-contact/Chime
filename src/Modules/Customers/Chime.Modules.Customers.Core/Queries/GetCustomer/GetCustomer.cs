using Chime.Shared.Abstractions.Queries;

namespace Chime.Modules.Customers.Core.Queries.GetCustomer;

internal class GetCustomer : IQuery<CustomerDetailsDto>
{
    public Guid CustomerId { get; set; }
}