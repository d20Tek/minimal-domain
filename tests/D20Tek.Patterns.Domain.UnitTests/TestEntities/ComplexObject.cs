//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain.UnitTests.TestEntities;

internal class ComplexObject : ValueObject
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    private ComplexObject(int id, string name, string value)
    {
        Id = id;
        Name = name;
        Description = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
        yield return Name;
        yield return Description;
    }

    public static ComplexObject Create(int id, string name, string desc) =>
        new(id, name, desc);
}
