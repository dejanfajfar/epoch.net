using System;

namespace Epoch.net;

/// <summary>
/// Implements <see cref="int"/> based helper methods
/// </summary>
public static class IntExtensions
{
    /// <summary>
    /// Transforms the given <see cref="int"/> into a <see cref="DateTime"/> structure
    /// </summary>
    /// <param name="epoch">The unix epoch</param>
    /// <returns>A <see cref="DateTime"/> initialized to the given offset in seconds from 1970-01-01T00:00Z</returns>
    public static DateTime ToDateTime(this int epoch)
    {
        return Constants.UnixEpoch.AddSeconds(epoch);
    }

    /// <summary>
    /// Transforms the given <see cref="int"/> into a <see cref="TimeSpan"/> structure
    /// </summary>
    /// <param name="epoch">The unix epoch</param>
    /// <returns>A <see cref="TimeSpan"/> representing the offset of 1970-01-01T00:00Z</returns>
    public static TimeSpan ToTimeSpan(this int epoch)
    {
        return TimeSpan.FromSeconds(epoch);
    }

    /// <summary>
    /// Transforms the given <see cref="int"/> into a <see cref="EpochTime"/>
    /// </summary>
    /// <param name="epoch">The unix epoch</param>
    /// <returns>A <see cref="EpochTime"/> initialized with the given unix epoch</returns>
    public static EpochTime ToEpochTime(this int epoch)
    {
        return new EpochTime(epoch);
    }

    /// <summary>
    /// Transforms the given <see cref="int"/> into a <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="epoch">The unix epoch</param>
    /// <returns>A <see cref="LongEpochTime"/> initialized with the given unix epoch</returns>
    public static LongEpochTime ToLongEpochTime(this int epoch)
    {
        return new LongEpochTime(epoch.ToLongEpochTimestamp());
    }

    /// <summary>
    /// Transforms the given seconds offset into a millisecond offset
    /// </summary>
    /// <param name="epoch">The unix epoch</param>
    /// <returns>The milliseconds from 1970-01-01T00:00Z</returns>
    public static long ToLongEpochTimestamp(this int epoch)
    {
        return epoch * 1000L;
    }
}