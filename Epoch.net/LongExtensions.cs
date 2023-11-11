using System;

namespace Epoch.net;

/// <summary>
/// Implements helper method in the <see cref="long"/> value type
/// </summary>
public static class LongExtensions
{
    /// <summary>
    /// Determines if the given LongEpochTimestamp is in the valid range for a <see cref="EpochTime"/>
    /// </summary>
    /// <param name="epoch">The LongEpochTimestamp</param>
    /// <returns>
    /// True if the EpochTimestamp is in a valid <see cref="EpochTime"/> range, False if not 
    /// </returns>
    public static bool IsValidEpochTimestamp(this long epoch) => epoch is >= EpochTime.MIN_VALUE and <= EpochTime.MAX_VALUE;

    /// <summary>
    /// Transforms the LongEpochTimestamp into a <see cref="DateTime"/>
    /// </summary>
    /// <param name="value">The LongEpochTimestamp</param>
    /// <returns>A <see cref="DateTime"/> representation of the given LongEpochTimestamp</returns>
    public static DateTime ToDateTime(this long value) => LongEpochTime.DefaultDateTime.AddMilliseconds(value);

    /// <summary>
    /// Transforms the LongEpochTimestamp into a <see cref="TimeSpan"/>
    /// </summary>
    /// <param name="value">The LongEpochTimestamp</param>
    /// <returns>The <see cref="TimeSpan"/> representation of the LongEpochTimestamp</returns>
    public static TimeSpan ToTimeSpan(this long value) => TimeSpan.FromMilliseconds(value);

    /// <summary>
    /// Transforms the LongEpochTimestamp into a EpochTimestamp
    /// </summary>
    /// <param name="value">The LongEpochTimestamp</param>
    /// <returns>
    ///  The LongEpochTimestamp converted from milliseconds to seconds and rounded to the next second
    /// </returns>
    /// <exception cref="EpochTimeValueException">
    /// If the value is outside of a <see cref="EpochTime"/> range
    /// </exception>
    public static int ToEpochTimestamp(this long value)
    {
        long seconds = value / 1000;

        return seconds.IsValidEpochTimestamp() ? Convert.ToInt32(seconds) : throw new EpochTimeValueException(value);
    }

    /// <summary>
    /// Transforms the LongEpochTimestamp into a <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="value">The LongEpochTimestamp</param>
    /// <returns>A <see cref="LongEpochTime"/> initialized with the LongEpochTimestamp</returns>
    public static LongEpochTime ToLongEpochTime(this long value) => new(value);
}