//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValueAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValueAreEqual(other);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }

    private bool ValueAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);

    public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);
}
