//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Minimal.Result;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace D20Tek.Minimal.Domain.UnitTests;

[TestClass]
public class UseCaseOperationTests
{
    [TestMethod]
    public async Task InvokeAsync_WithSuccessResponse_LogsStartEnd()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = await UseCaseOperation.InvokeAsync<string>(
            logger.Object,
            () =>
            {
                innerCheck = "called";
                return Task.FromResult<Result<string>>(innerCheck);
            },
            "TestMethod");

        // assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("called");

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(3));
    }

    [ExcludeFromCodeCoverage]
    [TestMethod]
    public async Task InvokeAsync_WithFailureResponse_LogsStartEnd()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = await UseCaseOperation.InvokeAsync<string>(
            logger.Object,
            () =>
            {
                innerCheck = "called";
                return Task.FromResult<Result<string>>(DefaultErrors.NotFound);
            },
            "TestMethod");

        // assert
        result.IsFailure.Should().BeTrue();
        result.ValueOrDefault.Should().BeNull();
        innerCheck.Should().Be("called");

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(2));
        logger.Verify(x => x.Log<It.IsAnyType>(
            LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public async Task InvokeAsyncNoResponse_WithSuccess_LogsStartEnd()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = await UseCaseOperation.InvokeAsync(
            logger.Object,
            () =>
            {
                innerCheck = "called";
                return Task.FromResult(Result<string>.Success());
            },
            "TestMethod");

        // assert
        result.IsSuccess.Should().BeTrue();
        innerCheck.Should().Be("called");

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(3));
    }

    [TestMethod]
    public async Task InvokeAsyncNoResponse_WithFailure_LogsStartEnd()
    {
        // arrange
        var logger = GetMockLogger();
        var innerCheck = "not called";

        // act
        var result = await UseCaseOperation.InvokeAsync(
            logger.Object,
            () =>
            {
                innerCheck = "called";
                return Task.FromResult<Result<string>>(DefaultErrors.NotFound);
            },
            "TestMethod");

        // assert
        result.IsFailure.Should().BeTrue();
        result.ValueOrDefault.Should().BeNull();
        innerCheck.Should().Be("called");

        logger.Verify(o => o.Log<It.IsAnyType>(
            LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(2));
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
