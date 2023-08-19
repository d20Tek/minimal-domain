//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.UnitTests.TestEntities;
using D20Tek.Patterns.Domain.Validations;

namespace D20Tek.Patterns.Domain.UnitTests.Validations;

[TestClass]
public class StringValidationsTests
{
    [TestMethod]
    public void NotEmpty_WithText_ReturnsTrue()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");

        // act
        var result = t1.FirstName.NotEmpty();

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void NotEmpty_WithNoText_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "", "McTest");

        // act
        var result = t1.FirstName.NotEmpty();

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InMaxLength_WithShortText_ReturnsTrue()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");

        // act
        var result = t1.LastName.InMaxLength(64);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InMaxLength_WithLongText_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest123456");

        // act
        var result = t1.LastName.InMaxLength(8);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void HasLength_WithCorrectText_ReturnsTrue()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "Tester", "McTest");

        // act
        var result = t1.FirstName.HasLength(4, 32);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void HasLength_WithShortText_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "foo", "McTest");

        // act
        var result = t1.FirstName.HasLength(4, 32);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void HasLength_WithLongText_ReturnsFalse()
    {
        // arrange
        var t1 = new TestEntity(Guid.NewGuid(), "foo-bar-tango-cash", "McTest");

        // act
        var result = t1.FirstName.HasLength(4, 8);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void IsValidEmailAddress_WithValidAddress_ReturnsTrue()
    {
        // arrange
        var email = "mctest@test.com";

        // act
        var result = email.IsValidEmailAddress();

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void IsValidEmailAddress_WithInvalidAddress_ReturnsFalse()
    {
        // arrange
        var email = "foo-bar";

        // act
        var result = email.IsValidEmailAddress();

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void IsValidEmailAddress_WithEmptyEmail_ReturnsFalse()
    {
        // arrange
        var email = "";

        // act
        var result = email.IsValidEmailAddress();

        // assert
        result.Should().BeFalse();
    }
}
