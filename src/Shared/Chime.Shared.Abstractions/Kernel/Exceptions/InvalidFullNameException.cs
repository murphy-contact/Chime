using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.Exceptions;

public class InvalidFullNameException : ChimeException
{
    public string FullName { get; }

    public InvalidFullNameException(string fullName) : base($"Full name: '{fullName}' is invalid.")
    {
        FullName = fullName;
    }
}