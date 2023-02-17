using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class CannotVerifyCustomerException : ChimeException
{
    public CannotVerifyCustomerException(Guid customerId)
        : base($"Customer with ID: '{customerId}' cannot be verified.")
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}