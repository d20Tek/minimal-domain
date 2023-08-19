//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain.UnitTests.TestEntities;

internal class TestId : ValueObject
{
    public Guid Value { get; init; }

    private TestId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static TestId CreateUnique() => new(Guid.NewGuid());

    public static TestId Create(Guid guid) => new(guid);
}
