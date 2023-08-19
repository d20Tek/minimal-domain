//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.UnitTests.TestEntities;

namespace D20Tek.Patterns.Domain.UnitTests;

[TestClass]
public class ValueObjectTests
{
    [TestMethod]
    public void GetAtomicValues_ReturnsValueList()
    {
        // arrange
        var id = TestId.CreateUnique();

        // act
        var result = id.GetAtomicValues();

        // assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(1);
        result.First().Should().BeOfType<Guid>();
    }

    [TestMethod]
    public void GetAtomicValues_WithComplexType_ReturnsValueList()
    {
        // arrange
        var id = ComplexObject.Create(101, "test", "description");

        // act
        var result = id.GetAtomicValues();

        // assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(3);
        result.First().Should().BeOfType<int>();
        result.Last().Should().BeOfType<string>();
    }

    [TestMethod]
    public void Equals_WithSimpleEqualObjects_ReturnsTrue()
    {
        // arrange
        var guid = Guid.NewGuid();
        var id1 = TestId.Create(guid);
        var id2 = TestId.Create(guid);

        // act
        var result = id1 == id2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WithEqualObjects_ReturnsTrue()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");
        var id2 = ComplexObject.Create(101, "test", "description");

        // act
        var result = id1 == id2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WithNotEqualObjects_ReturnsTrue()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");
        var id2 = ComplexObject.Create(101, "test3", "description");

        // act
        var result = id1 == id2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Inequality_WithEqualObjects_ReturnsTrue()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");
        var id2 = ComplexObject.Create(101, "test", "description");

        // act
        var result = id1 != id2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Inequality_WithNotEqualObjects_ReturnsTrue()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");
        var id2 = ComplexObject.Create(111, "test", "description");

        // act
        var result = id1 != id2;

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GetHashcode_WithEqualObjects_ReturnsSameValue()
    {
        // arrange
        var guid = Guid.NewGuid();

        // act
        var hash1 = TestId.Create(guid).GetHashCode();
        var hash2 = TestId.Create(guid).GetHashCode();

        // assert
        hash1.Should().Be(hash2);
    }

    [TestMethod]
    public void GetHashcode_WithNotEqualObjects_ReturnsDifferentValues()
    {
        // arrange

        // act
        var hash1 = TestId.Create(Guid.NewGuid()).GetHashCode();
        var hash2 = TestId.Create(Guid.NewGuid()).GetHashCode();

        // assert
        hash1.Should().NotBe(hash2);
    }

    [TestMethod]
    public void TypedEquals_WithEqualObjects_ReturnsTrue()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");
        var id2 = ComplexObject.Create(101, "test", "description");

        // act
        var result = id1.Equals(id2);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void TypedEquals_WithNullOther_ReturnsFalse()
    {
        // arrange
        var id1 = ComplexObject.Create(101, "test", "description");

        // act
        var result = id1.Equals(null);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void ObjectEquals_WithNullOther_ReturnsFalse()
    {
        // arrange
        object id1 = ComplexObject.Create(101, "test", "description");

        // act
        var result = id1.Equals(null);

        // assert
        result.Should().BeFalse();
    }
}