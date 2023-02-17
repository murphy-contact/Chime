using Chime.Shared.Abstractions.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.Exceptions;

public class UnsupportedNationalityException : ChimeException
{
    public string Nationality { get; }

    public UnsupportedNationalityException(string nationality) : base($"Nationality: '{nationality}' is unsupported.")
    {
        Nationality = nationality;
    }
}