//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Minimal.Domain.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Minimal.Domain.UnitTests;

[TestClass]
public class AggreateRootTests
{
    internal class TestAggregate : AggregateRoot<Guid>
    {
        public TestAggregate(Guid id)
            : base(id)
        {
        }

        internal void MakeChange()
        {
            AddDomainEvent(new Event1(Id.ToString(), "TestEvent"));

            AddDomainEvent(new Event2(Id));
        }
    }

    [ExcludeFromCodeCoverage]
    internal record Event1(string Id, string Name) : IDomainEvent;

    [ExcludeFromCodeCoverage]
    internal record Event2(Guid Id) : IDomainEvent;

    [TestMethod]
    public void Create_StartsWith_EmptyDomainEvents()
    {
        // arrange

        // act
        var agg = new TestAggregate(Guid.NewGuid());

        // assert
        agg.Should().NotBeNull();
        agg.DomainEvents.Should().BeEmpty();
    }

    [TestMethod]
    public void AddDomainEvent_AppendsEvents_ToList()
    {
        // arrange
        var id = Guid.NewGuid();
        var agg = new TestAggregate(id);

        // act
        agg.MakeChange();

        // assert
        agg.DomainEvents.Should().HaveCount(2);
    }

    [TestMethod]
    public void ClearDomainEvent_ResetsEvents_ToEmptyList()
    {
        // arrange
        var id = Guid.NewGuid();
        var agg = new TestAggregate(id);
        agg.MakeChange();

        // act
        agg.ClearDomainEvents();

        // assert
        agg.DomainEvents.Should().BeEmpty();
    }
}
