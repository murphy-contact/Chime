using Chime.Shared.Abstractions.Kernel.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.ValueObjects;

public class Nationality : IEquatable<Nationality>
{
    private static readonly HashSet<string> AllowedValues = new()
    {
        "PL", "DE", "FR", "ES", "GB"
    };

    public Nationality(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 2) throw new InvalidNationalityException(value);

        value = value.ToUpperInvariant();
        if (!AllowedValues.Contains(value)) throw new UnsupportedNationalityException(value);

        Value = value;
    }

    public string Value { get; }

    public bool Equals(Nationality other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public static implicit operator Nationality(string value)
    {
        return value is null ? null : new Nationality(value);
    }

    public static implicit operator string(Nationality value)
    {
        return value?.Value;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Nationality)obj);
    }

    public override int GetHashCode()
    {
        return Value is not null ? Value.GetHashCode() : 0;
    }

    public override string ToString()
    {
        return Value;
    }
}