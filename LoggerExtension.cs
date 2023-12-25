﻿using Microsoft.Extensions.Logging;

namespace TestFuntionApp;

public static class LoggerExtensions
{

    private static IDisposable BeginNoSampleScope(this ILogger logger)
    {
        return logger.BeginScope(new Dictionary<string, object>
        {
            ["NoSample"] = "True"
        });
    }

    public static void LogWarningWithNoSampling(this ILogger logger, string message, params object[]? args)
    {
        using (logger.BeginNoSampleScope())
        {
            logger.LogWarning(message, args);
        }
    }

    public static void LogInfoWithNoSampling(this ILogger logger, string message, params object[]? args)
    {
        using (logger.BeginNoSampleScope())
        {
            logger.LogInformation(message, args);
        }
    }

    public static void LogErrorWithNoSampling(this ILogger logger, string message, params object[]? args)
    {
        using (logger.BeginNoSampleScope())
        {
            logger.LogError(message, args);
        }
    }

    public static void LogErrorWithNoSampling(this ILogger logger, Exception ex, string message, params object[]? args)
    {
        using (logger.BeginNoSampleScope())
        {
            logger.LogError(ex, message, args);
        }
    }
}

