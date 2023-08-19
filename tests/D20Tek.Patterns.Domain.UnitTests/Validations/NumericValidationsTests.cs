//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.Validations;

namespace D20Tek.Patterns.Domain.UnitTests.Validations;

[TestClass]
public class NumericValidationsTests
{
    [TestMethod]
    public void InRange_WithMiddleValue_ReturnsTrue()
    {
        // arrange
        int x = 8;

        // act
        var result = x.InRange(4, 12);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InRange_WithMinValue_ReturnsTrue()
    {
        // arrange
        decimal x = 4;

        // act
        var result = x.InRange(4, 12);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InRange_WithLessThanMinValue_ReturnsFalse()
    {
        // arrange
        double x = 2;

        // act
        var result = x.InRange(4, 12);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InRange_WithMaxValue_ReturnsTrue()
    {
        // arrange
        decimal x = 12;

        // act
        var result = x.InRange(4, 12);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void InRange_WithGreaterThanMaxValue_ReturnsFalse()
    {
        // arrange
        double x = 24;

        // act
        var result = x.InRange(4, 12);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InRange_WithMaxValueNonInclusive_ReturnsFalse()
    {
        // arrange
        float x = 12;

        // act
        var result = x.InRange(4, 12, false);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void InRange_WithMinValueNonInclusive_ReturnsFalse()
    {
        // arrange
        long x = 4;

        // act
        var result = x.InRange(4, 12, false);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void GreaterThan_WithLargeValue_ReturnsTrue()
    {
        // arrange
        int x = 1800;

        // act
        var result = x.GreaterThan(100);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GreaterThan_WithMaxValue_ReturnsTrue()
    {
        // arrange
        int x = 100;

        // act
        var result = x.GreaterThan(100);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void GreaterThan_WithLowValue_ReturnsFalse()
    {
        // arrange
        int x = 1;

        // act
        var result = x.GreaterThan(100);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void GreaterThan_WithMaxValueNonInclusive_ReturnsFalse()
    {
        // arrange
        int x = 100;

        // act
        var result = x.GreaterThan(100, false);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void LessThan_WithSmallValue_ReturnsTrue()
    {
        // arrange
        int x = 18;

        // act
        var result = x.LessThan(100);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void LessThan_WithMaxValue_ReturnsTrue()
    {
        // arrange
        int x = 100;

        // act
        var result = x.LessThan(100);

        // assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void LessThan_WithLargeValue_ReturnsFalse()
    {
        // arrange
        int x = 101;

        // act
        var result = x.LessThan(100);

        // assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void LessThan_WithMinValueNonInclusive_ReturnsFalse()
    {
        // arrange
        int x = 100;

        // act
        var result = x.LessThan(100, false);

        // assert
        result.Should().BeFalse();
    }
}
