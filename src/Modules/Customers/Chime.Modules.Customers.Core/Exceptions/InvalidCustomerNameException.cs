using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidCustomerNameException : ChimeException
{
    public InvalidCustomerNameException(Guid customerId)
        : base($"Customer with ID: '{customerId}' has invalid name.")
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}