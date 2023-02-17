using System.Globalization;
using Chime.Shared.Abstractions.Kernel.Exceptions;

namespace Chime.Shared.Abstractions.Kernel.ValueObjects;

public class Amount : IEquatable<Amount>
{
    public Amount(decimal value)
    {
        if (value is < 0 or > 1000000) throw new InvalidAmountException(value);

        Value = value;
    }

    public decimal Value { get; }

    public static Amount Zero => new(0);

    public bool Equals(Amount other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public static implicit operator Amount(decimal value)
    {
        return new Amount(value);
    }

    public static implicit operator decimal(Amount value)
    {
        return value.Value;
    }

    public static bool operator ==(Amount a, Amount b)
    {
        if (ReferenceEquals(a, b)) return true;

        if (a is not null && b is not null) return a.Value.Equals(b.Value);

        return false;
    }

    public static bool operator !=(Amount a, Amount b)
    {
        return !(a == b);
    }

    public static bool operator >(Amount a, Amount b)
    {
        return a.Value > b.Value;
    }

    public static bool operator <(Amount a, Amount b)
    {
        return a.Value < b.Value;
    }

    public static bool operator >=(Amount a, Amount b)
    {
        return a.Value >= b.Value;
    }

    public static bool operator <=(Amount a, Amount b)
    {
        return a.Value <= b.Value;
    }

    public static Amount operator +(Amount a, Amount b)
    {
        return a.Value + b.Value;
    }

    public static Amount operator -(Amount a, Amount b)
    {
        return a.Value - b.Value;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Amount)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}