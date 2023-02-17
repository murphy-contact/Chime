using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidCustomerEmailException : ChimeException
{
    public Guid CustomerId { get; }

    public InvalidCustomerEmailException(Guid customerId)
        : base($"Customer with ID: '{customerId}' has invalid email.")
    {
        CustomerId = customerId;
    }
}