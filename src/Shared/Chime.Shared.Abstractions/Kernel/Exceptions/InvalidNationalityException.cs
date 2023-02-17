using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.Exceptions;

public class InvalidNationalityException : ChimeException
{
    public InvalidNationalityException(string? nationality) : base($"Nationality: '{nationality}' is invalid.")
    {
        Nationality = nationality;
    }

    public string? Nationality { get; }
}