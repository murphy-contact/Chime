using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class CustomerNotActiveException : ChimeException
{
    public Guid CustomerId { get; }

    public CustomerNotActiveException(Guid customerId)
        : base($"Customer with ID: '{customerId}' is not active.")
    {
        CustomerId = customerId;
    }
}