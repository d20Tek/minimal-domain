//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.Validations;

namespace D20Tek.Patterns.Domain.UnitTests.Validations;

[TestClass]
public class GuidValidations
{
    [TestMethod]
    public void NotEmpty_WithGuid_ReturnsTrue()
    {
        // arrange
        var guid = Guid.NewGuid();

        // act
        var result = guid.NotEmpty();

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void NotEmpty_WithEmptyGuid_ReturnsFalse()
    {
        // arrange
        var guid = Guid.Empty;

        // act
        var result = guid.NotEmpty();

        // assert
        result.Should().BeFalse();
    }
}
