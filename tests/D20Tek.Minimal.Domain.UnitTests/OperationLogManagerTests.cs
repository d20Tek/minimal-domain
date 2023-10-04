//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Minimal.Domain.UnitTests;

[TestClass]
[ExcludeFromCodeCoverage]
public class OperationLogManagerTests
{
    [TestMethod]
    public async Task OperationAsync_WithSuccess_DoesNotLog()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = await OperationLogManager.OperationAsync<string>(
            () =>
            {
                innerCheck = "called";
                return Task.FromResult(innerCheck);
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().NotBeNull();
        result.Should().Be(innerCheck);

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [TestMethod]
    public async Task OperationAsync_WithException_LogsError()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = await OperationLogManager.OperationAsync<string>(
            () =>
            {
                throw new InvalidOperationException();
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeNull();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public void Operation_WithSuccess_DoesNotLog()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = OperationLogManager.Operation<string>(
            () =>
            {
                innerCheck = "called";
                return innerCheck;
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().NotBeNull();
        result.Should().Be(innerCheck);

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [TestMethod]
    public void Operation_WithException_LogsError()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = OperationLogManager.Operation<string>(
            () =>
            {
                throw new InvalidOperationException();
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeNull();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public async Task ValueOperationAsync_WithSuccess_DoesNotLog()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = await OperationLogManager.ValueOperationAsync<bool>(
            () =>
            {
                return Task.FromResult(true);
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeTrue();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [TestMethod]
    public async Task ValueOperationAsync_WithException_LogsError()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = await OperationLogManager.ValueOperationAsync<bool>(
            () =>
            {
                throw new InvalidOperationException();
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeFalse();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public void ValueOperation_WithSuccess_DoesNotLog()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = OperationLogManager.ValueOperation<bool>(
            () =>
            {
                return true;
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeTrue();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [TestMethod]
    public void ValueOperation_WithException_LogsError()
    {
        // arrange
        var logger = GetMockLogger();

        // act
        var result = OperationLogManager.ValueOperation<bool>(
            () =>
            {
                throw new InvalidOperationException();
            },
            logger.Object,
            "TestMethod");

        // assert
        result.Should().BeFalse();

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    private Mock<ILogger> GetMockLogger()
    {
        return new Mock<ILogger>();
    }
}
