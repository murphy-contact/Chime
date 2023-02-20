using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Users.Core.Exceptions;

internal class EmailInUseException : ChimeException
{
    public EmailInUseException() : base("Email is already in use.")
    {
    }
}