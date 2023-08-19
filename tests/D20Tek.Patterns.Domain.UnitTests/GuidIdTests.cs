//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain.UnitTests;

[TestClass]
public class GuidIdTests
{
    [TestMethod]
    public void GetAtomicValues_ReturnsSingleItemList()
    {
        // arrange
        var id = GuidId.CreateUnique();

        // act
        var result = id.GetAtomicValues();

        // assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(1);
        result.First().Should().BeOfType<Guid>();
    }

    [TestMethod]
    public void Equals_WithDifferentGuidIds_ReturnsFalse()
    {
        // arrange
        var id1 = GuidId.CreateUnique();
        var id2 = GuidId.CreateUnique();

        // act
        var result = id1 == id2;

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void ToString_ReturnsStringifiedValue()
    {
        // arrange
        var id = GuidId.CreateUnique();

        // act
        var result = id.ToString();

        // assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Be(id.Value.ToString());
    }
}
