using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidAddressException : ChimeException
{
    public string Address { get; }

    public InvalidAddressException(string address) : base($"Address: '{address}' is invalid.")
    {
        Address = address;
    }
}