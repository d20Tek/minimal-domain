//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Minimal.Domain.UnitTests.TestEntities;

internal class TestEntity : Entity<Guid>
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public TestEntity(Guid id, string fn, string ln)
        : base(id)
    {
        FirstName = fn;
        LastName = ln;
    }
}
