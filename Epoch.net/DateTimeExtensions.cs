using System;

namespace Epoch.net;

/// <summary>
/// Implements utility methods on the <see cref="DateTime"/> structure
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Transforms the given <see cref="DateTime"/> into a LongEpochTimestamp
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> structure to convert into an LongEpochTimestamp</param>
    /// <returns>The number of milliseconds since 1970-01-01T00:00Z</returns>
    /// <remarks>The LongEpochTimestamp is the number of milliseconds since 1970-01-01T00:00Z</remarks>
    public static long ToLongEpochTimestamp(this DateTime dateTime)
    {
        var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
        
        return Convert.ToInt64(timeSinceDisco.TotalMilliseconds);
    }

    /// <summary>
    /// Transforms the given <see cref="DateTime"/> into the EpochTimestamp
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> structure to convert into a EpochTimestamp</param>
    /// <returns>The number of seconds since 1970-01-01T00:00Z</returns>
    /// <exception cref="EpochTimeValueException">
    /// If the <see cref="DateTime"/> exceeded the valid range of a Unix Epoch 
    /// </exception>
    /// <remarks>The EpochTimestamp is the number of seconds since the 1970-01-01T00:00Z</remarks>
    public static int ToEpochTimestamp(this DateTime dateTime)
    {
        if (!dateTime.IsValidEpochTime())
        {
            throw new EpochTimeValueException(dateTime);
        }
        
        var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
        
        return Convert.ToInt32(timeSinceDisco.TotalSeconds);
    }

    /// <summary>
    /// Transforms the given <see cref="DateTime"/> into a <see cref="EpochTime"/>
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> structure to convert into a <see cref="EpochTime"/></param>
    /// <returns>A <see cref="EpochTime"/> representation of the given <see cref="DateTime"/> structure</returns>
    /// <exception cref="EpochTimeValueException">
    /// If the <see cref="DateTime"/> exceeded the valid range of a Unix Epoch
    /// </exception>
    public static EpochTime ToEpochTime(this DateTime dateTime)
    {
        if (!dateTime.IsValidEpochTime())
        {
            throw new EpochTimeValueException(dateTime);
        }
        
        return new EpochTime(dateTime);
    }

    /// <summary>
    /// Transforms the given <see cref="DateTime"/> into a <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> structure to convert into a <see cref="LongEpochTime"/></param>
    /// <returns>A <see cref="LongEpochTime"/> representation of the given <see cref="DateTime"/></returns>
    public static LongEpochTime ToLongEpochTime(this DateTime dateTime)
    {
        return new LongEpochTime(dateTime);
    }

    /// <summary>
    /// Determines if the given <see cref="DateTime"/> is in a valid <see cref="EpochTime"/> range
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> structure to test</param>
    /// <returns>True if the <see cref="DateTime"/> is in a valid <see cref="EpochTime"/> range, False if not</returns>
    public static bool IsValidEpochTime(this DateTime dateTime)
    {
        return dateTime >= Constants.MIN_VALUE_DATETIME && dateTime <= Constants.MAX_VALUE_DATETIME;
    }
}