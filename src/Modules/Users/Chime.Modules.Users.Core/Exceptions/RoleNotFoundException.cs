using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Modules.Users.Core.Exceptions;

internal class RoleNotFoundException : ChimeException
{
    public RoleNotFoundException(string role) : base($"Role: '{role}' was not found.")
    {
    }
}