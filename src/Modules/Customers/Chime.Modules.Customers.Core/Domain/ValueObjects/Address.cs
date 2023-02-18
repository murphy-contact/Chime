using Chime.Modules.Customers.Core.Exceptions;

namespace Chime.Modules.Customers.Core.Domain.ValueObjects;

internal class Address : IEquatable<Address>
{
    public Address(string? value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 200 or < 3) throw new InvalidAddressException(value);

        Value = value.Trim();
    }

    public string? Value { get; }

    public bool Equals(Address? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public static implicit operator Address?(string? value)
    {
        return value is null ? null : new Address(value);
    }

    public static implicit operator string?(Address? value)
    {
        return value?.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Address)obj);
    }

    public override int GetHashCode()
    {
        return Value is not null ? Value.GetHashCode() : 0;
    }

    public override string? ToString()
    {
        return Value;
    }
}