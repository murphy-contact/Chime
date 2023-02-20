using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Users.Core.Exceptions;

internal class InvalidEmailException : ChimeException
{
    public InvalidEmailException(string email) : base($"State is invalid: '{email}'.")
    {
        Email = email;
    }

    public string Email { get; }
}