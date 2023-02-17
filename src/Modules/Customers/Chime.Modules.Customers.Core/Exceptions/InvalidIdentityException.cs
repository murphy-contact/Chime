using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidIdentityException : ChimeException
{
    public InvalidIdentityException(string type, string series)
        : base($"Identity type: '{type}', series: '{series}' is invalid.")
    {
        Type = type;
    }

    public string Type { get; }
}