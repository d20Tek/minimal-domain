//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace D20Tek.Minimal.Domain;

public static class OperationLogManager
{
    public static async Task<TResult?> OperationAsync<TResult>(
        Func<Task<TResult>> operation,
        ILogger logger,
        [CallerMemberName] string caller = "method")
    {
        try
        {
            return await operation.Invoke();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error processing {caller} operation.");
            return default;
        }
    }

    public static TResult? Operation<TResult>(
        Func<TResult> operation,
        ILogger logger,
        [CallerMemberName] string caller = "method")
    {
        try
        {
            return operation.Invoke();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error processing {caller} operation.");
            return default;
        }
    }

    public static async Task<TResult> ValueOperationAsync<TResult>(
        Func<Task<TResult>> operation,
        ILogger logger,
        [CallerMemberName] string caller = "method")
        where TResult : struct
    {
        try
        {
            return await operation.Invoke();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error processing {caller} operation.");
            return default;
        }
    }

    public static TResult ValueOperation<TResult>(
        Func<TResult> operation,
        ILogger logger,
        [CallerMemberName] string caller = "method")
        where TResult : struct
    {
        try
        {
            return operation.Invoke();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error processing {caller} operation.");
            return default;
        }
    }
}
