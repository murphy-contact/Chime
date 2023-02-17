namespace Chime.Shared.Abstractions.Exceptions;

public abstract class ChimeException : Exception
{
    protected ChimeException(string message) : base(message)
    {
    }
}