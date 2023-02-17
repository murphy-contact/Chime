using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.Exceptions;

public class InvalidNationalityException : ChimeException
{
    public string Nationality { get; }

    public InvalidNationalityException(string nationality) : base($"Nationality: '{nationality}' is invalid.")
    {
        Nationality = nationality;
    }
}