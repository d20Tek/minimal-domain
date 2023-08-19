//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.UnitTests.TestEntities;

namespace D20Tek.Patterns.Domain.UnitTests;

[TestClass]
public class EntityTests
{
    [TestMethod]
    public void Equals_WithEqualIds_ReturnsTrue()
    {
        // arrange
        var id = Guid.NewGuid();
        var t1 = new TestEntity(id, "Tester1", "McTest");
        var t2 = new TestEntity(id, "Tester2", "O'Test");

        // act
        var result = t1 == t2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WithNotEqualIds_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");
        var t2 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");

        // act
        var result = t1 == t2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Inequality_WithEqualIds_ReturnsTrue()
    {
        // arrange
        var id = Guid.NewGuid();
        var t1 = new TestEntity(id, "Tester1", "McTest");
        var t2 = new TestEntity(id, "Tester2", "O'Test");

        // act
        var result = t1 != t2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Inequality_WithNotEqualIds_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");
        var t2 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");

        // act
        var result = t1 != t2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GetHashCode_WithEqualIds_AreEqual()
    {
        // arrange
        var id = Guid.NewGuid();
        var h1 = new TestEntity(id, "Tester1", "McTest").GetHashCode();
        var h2 = new TestEntity(id, "Tester2", "O'Test").GetHashCode();

        // act
        var result = h1 == h2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GetHashCode_WithNotEqualIds_AreNotEqual()
    {
        // arrange
        var h1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest").GetHashCode();
        var h2 = new TestEntity(Guid.NewGuid(), "Tester", "McTest").GetHashCode();

        // act
        var result = h1 == h2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void TypedEquals_WithEqualObjects_ReturnsTrue()
    {
        // arrange
        var id = Guid.NewGuid();
        var t1 = new TestEntity(id, "test", "description");
        var t2 = new TestEntity(id, "test", "description");

        // act
        var result = t1.Equals(t2);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void TypedEquals_WithNullOther_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "test", "description");

        // act
        var result = t1.Equals(null);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void ObjectEquals_WithNullOther_ReturnsFalse()
    {
        // arrange
        object t1 = new TestEntity(Guid.NewGuid(), "test", "description");

        // act
        var result = t1.Equals(null);

        // assert
        result.Should().BeFalse();
    }
}
