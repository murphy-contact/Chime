using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Users.Core.Exceptions;

internal class SignUpDisabledException : ChimeException
{
    public SignUpDisabledException() : base("Sign up is disabled.")
    {
    }
}