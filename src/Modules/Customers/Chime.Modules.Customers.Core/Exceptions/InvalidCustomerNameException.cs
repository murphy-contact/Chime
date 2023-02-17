using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidCustomerNameException : ChimeException
{
    public Guid CustomerId { get; }

    public InvalidCustomerNameException(Guid customerId)
        : base($"Customer with ID: '{customerId}' has invalid name.")
    {
        CustomerId = customerId;
    }
}