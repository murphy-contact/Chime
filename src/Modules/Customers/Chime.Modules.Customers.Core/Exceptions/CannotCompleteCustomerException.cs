using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class CannotCompleteCustomerException : ChimeException
{
    public CannotCompleteCustomerException(Guid customerId)
        : base($"Customer with ID: '{customerId}' cannot be completed.")
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}