using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.Exceptions;

public class InvalidEmailException : ChimeException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }
}