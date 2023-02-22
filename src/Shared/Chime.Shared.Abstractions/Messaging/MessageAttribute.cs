namespace Chime.Shared.Abstractions.Messaging;

[AttributeUsage(AttributeTargets.Class)]
public class MessageAttribute : Attribute
{
    public MessageAttribute(string module = null, bool enabled = true)
    {
        Module = module ?? string.Empty;
        Enabled = enabled;
    }

    public string Module { get; }
    public bool Enabled { get; }
}