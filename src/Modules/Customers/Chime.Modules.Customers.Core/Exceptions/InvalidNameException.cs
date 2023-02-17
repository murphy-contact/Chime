using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Customers.Core.Exceptions;

internal class InvalidNameException : ChimeException
{
    public InvalidNameException(string name) : base($"Name: '{name}' is invalid.")
    {
        Name = name;
    }

    public string Name { get; }
}