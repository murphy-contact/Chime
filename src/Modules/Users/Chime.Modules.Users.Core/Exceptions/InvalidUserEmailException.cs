using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Users.Core.Exceptions;

internal class InvalidUserEmailException : ChimeException
{
    public InvalidUserEmailException(Guid userId)
        : base($"User with ID: '{userId}' has invalid email.")
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}