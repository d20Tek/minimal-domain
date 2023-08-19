//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain;

public class GuidId : ValueObject
{
    public Guid Value { get; init; }

    protected GuidId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();

    public static GuidId CreateUnique() => new(Guid.NewGuid());
}
