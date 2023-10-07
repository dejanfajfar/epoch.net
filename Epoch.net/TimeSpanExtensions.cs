using System;

namespace Epoch.net;

/// <summary>
/// Implements helper methods based on the <see cref="TimeSpan"/> structure
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Transforms the given <see cref="TimeSpan"/> into a <see cref="EpochTime"/>
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>A new <see cref="EpochTime"/> instance initialized with the given <see cref="TimeSpan"/></returns>
    public static EpochTime ToEpochTime(this TimeSpan timeSpan)
    {
        return new EpochTime(timeSpan);
    }

    /// <summary>
    /// Transforms the given <see cref="TimeSpan"/> into a EpochTimestamp
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>The number of seconds the given <see cref="TimeSpan"/> represents</returns>
    /// <exception cref="EpochTimeValueException">
    /// If the given <see cref="TimeSpan"/> is not in a valid <see cref="EpochTime"/> range
    /// </exception>
    public static int ToEpochTimestamp(this TimeSpan timeSpan)
    {
        var totalSeconds = timeSpan.TotalSeconds;

        if (!timeSpan.IsValidEpochTime())
        {
            throw new EpochTimeValueException(timeSpan);
        }

        return Convert.ToInt32(totalSeconds);
    }

    /// <summary>
    /// Transforms the given <see cref="TimeSpan"/> into a <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>A <see cref="LongEpochTime"/> representation of the given <see cref="TimeSpan"/></returns>
    public static LongEpochTime ToLongEpochTime(this TimeSpan timeSpan)
    {
        return new LongEpochTime(timeSpan);
    }

    /// <summary>
    /// Transforms the given <see cref="TimeSpan"/> into a LongEpochTimestamp
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>The milliseconds represented by the given <see cref="TimeSpan"/></returns>
    /// <exception cref="LongEpochTimeValueException">
    /// If the number of milliseconds exceeds the <see cref="LongEpochTime"/> range
    /// </exception>
    public static long ToLongEpochTimestamp(this TimeSpan timeSpan)
    {
        var totalMilliseconds = timeSpan.TotalMilliseconds;

        if (!timeSpan.IsValidLongEpochTime())
        {
            throw new LongEpochTimeValueException(timeSpan);
        }

        return Convert.ToInt64(totalMilliseconds);
    }

    /// <summary>
    /// Determines if the given <see cref="TimeSpan"/> is in a valid <see cref="EpochTime"/> range
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>
    /// True if the given <see cref="TimeSpan"/> is in the valid range, False if not
    /// </returns>
    public static bool IsValidEpochTime(this TimeSpan timeSpan)
    {
        var totalSeconds = timeSpan.TotalSeconds;

        return totalSeconds >= Constants.MIN_VALUE_INT && totalSeconds <= Constants.MAX_VALUE_INT;
    }

    /// <summary>
    /// Determines if the given <see cref="TimeSpan"/> is in a valid <see cref="LongEpochTime"/> range
    /// </summary>
    /// <param name="timeSpan">The given <see cref="TimeSpan"/></param>
    /// <returns>
    /// True if the given <see cref="TimeSpan"/> is in the valid range, False if not
    /// </returns>
    public static bool IsValidLongEpochTime(this TimeSpan timeSpan)
    {
        var totalMilliseconds = timeSpan.TotalMilliseconds;

        return totalMilliseconds >= Constants.MIN_VALUE_LONG && totalMilliseconds <= Constants.MAX_VALUE_LONG;
    }
}