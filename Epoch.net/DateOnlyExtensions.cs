using System;

namespace Epoch.net;
#if NET6_0_OR_GREATER
public static class DateOnlyExtensions
{
    /// <summary>
    /// Transforms the given <see cref="DateOnly"/> structure into a <see cref="EpochTime"/>
    /// </summary>
    /// <param name="date">The <see cref="DateOnly"/> structure to convert into the <see cref="EpochTime"/></param>
    /// <returns>
    /// A new instance of <see cref="EpochTime"/> representaiton of the given <see cref="DateOnly"/> structure
    /// </returns>
    /// <exception cref="EpochTimeValueException">
    /// If the <paramref name="date"/> exceeded the valid range of a Unix Epoch 
    /// </exception>
    public static EpochTime ToEpochTime(this DateOnly date) => date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc).ToEpochTime();

    /// <summary>
    /// Transforms the given <see cref="DateOnly"/> structure into a <see cref="EpochTime"/> with the given <see cref="TimeOnly"/> offset
    /// </summary>
    /// <param name="date">The <see cref="DateOnly"/> structure to convert into the <see cref="EpochTime"/></param>
    /// <param name="time">The <see cref="TimeOnly"/> structure used for the time ofdfset from midnight</param>
    /// <param name="isUtcTime">Determines if the given <see cref="TimeOnly"/> is UTC or local time. TRUE => UTC, FALSE => Local time </param>
    /// <remarks>
    /// It is assumed that the <paramref name="time"/> is UTC time. Determined by the <paramref name="isUtcTime"/>
    /// </remarks>
    /// <returns>
    /// A new instance of <see cref="EpochTime"/> representaiton of the given <see cref="DateOnly"/> and <see cref="TimeOnly"/> structure
    /// </returns>
    /// <exception cref="EpochTimeValueException">
    /// If the <paramref name="date"/> exceeded the valid range of a Unix Epoch 
    /// </exception>
    public static EpochTime ToEpochTime(this DateOnly date, TimeOnly time, bool isUtcTime = true) => isUtcTime switch
    {
        true => date.ToDateTime(time, DateTimeKind.Utc).ToEpochTime(),
        false => date.ToDateTime(time, DateTimeKind.Local).ToEpochTime()
    };
}
#endif
