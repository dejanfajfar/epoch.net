using System;

namespace Epoch.net;

/// <summary>
/// Implements a millisecond precise unix epoch
/// </summary>
public sealed class LongEpochTime
{
    private static IDateTimeProvider timeProvider;

    static LongEpochTime() => timeProvider = new DefaultTimeProvider();

    /// <summary>
    /// The default value of <see cref="LongEpochTime"/>
    /// </summary>
    /// <remarks>
    /// Thursday, January 1, 1970 12:00:00 AM GMT
    /// </remarks>
    public static LongEpochTime Default => new(0);

    /// <summary>
    /// The default date time value of an <see cref="LongEpochTime"/> 
    /// </summary>
    /// /// <remarks>
    /// Thursday, January 1, 1970 12:00:00 AM GMT
    /// </remarks>
    public static DateTime DefaultDateTime => new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// The minimal possible <see cref="long"/> value of a <see cref="LongEpochTime"/>
    /// </summary>
    public const long MAX_VALUE = 922337203685477;
    /// <summary>
    /// The maximal possible <see cref="long"/> value of a <see cref="LongEpochTime"/>
    /// </summary>
    public const long MIN_VALUE = -922337203685477;

    /// <summary>
    /// The minimal value of a <see cref="LongEpochTime"/>
    /// </summary>
    public static LongEpochTime MIN => new(MIN_VALUE);
    /// <summary>
    /// The maximal value of a <see cref="LongEpochTime"/>
    /// </summary>
    public static LongEpochTime MAX => new(MAX_VALUE);

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> from which to initialize the instance</param>
    public LongEpochTime(DateTime dateTime) => rawEpoch = dateTime.ToLongEpochTimestamp();

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="longEpochTimestamp">The number of milliseconds since 1970-01-01T00:00Z</param>
    public LongEpochTime(long longEpochTimestamp) => rawEpoch = longEpochTimestamp;

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> offset from 1970-01-01T00:00Z</param>
    /// <exception cref="LongEpochTimeValueException">
    ///  If the <see cref="TimeSpan"/> is not in a valid <see cref="LongEpochTime"/> range
    /// </exception>
    public LongEpochTime(TimeSpan timeSpan)
    {
        if (!timeSpan.IsValidLongEpochTime())
        {
            throw new LongEpochTimeValueException(timeSpan);
        }

        rawEpoch = timeSpan.ToLongEpochTimestamp();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="longEpochTime">The <see cref="LongEpochTime"/> from which to take the initialization data</param>
    /// <exception cref="ArgumentNullException">
    /// If the given <see cref="LongEpochTime"/> is null
    /// </exception>
    public LongEpochTime(LongEpochTime longEpochTime)
    {
        if (longEpochTime == null)
        {
            throw new ArgumentNullException(nameof(longEpochTime), "The provided LongEpochTime can not be null");
        }

        rawEpoch = longEpochTime.Epoch;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="epochTime">The <see cref="EpochTime"/> from which to take the initialization data</param>
    /// <exception cref="ArgumentNullException">
    ///  If the provided <see cref="EpochTime"/> is null
    /// </exception>
    public LongEpochTime(EpochTime epochTime)
    {
        if (epochTime == null)
        {
            throw new ArgumentNullException(nameof(epochTime), "The provided EpochTime can not be null");
        }

        rawEpoch = epochTime.Epoch.ToLongEpochTimestamp();
    }

    private long rawEpoch { get; set; }

    /// <summary>
    /// Injects a new global thread safe <see cref="IDateTimeProvider"/> instance to be used globally
    /// </summary>
    /// <param name="timeProvider">The new time provider instance</param>
    public static void SetTimeProvider(IDateTimeProvider timeProvider)
    {
        if (timeProvider != null)
        {
            LongEpochTime.timeProvider = timeProvider;
        }
    }

    /// <summary>
    /// Resets the global time provider to the default system time provider 
    /// </summary>
    public static void ResetTimeProvider() => timeProvider = new DefaultTimeProvider();

    /// <summary>
    /// Gets the current UTC date and time as an <see cref="LongEpochTime"/>
    /// </summary>
    public static LongEpochTime Now => timeProvider.UtcNow.ToLongEpochTime();

    /// <summary>
    /// Gets a millisecond unix epoch representation of the <see cref="LongEpochTime"/> instance
    /// </summary>
    public long Epoch => rawEpoch;

    /// <summary>
    /// Get a <see cref="DateTime"/> representation of the <see cref="LongEpochTime"/> instance
    /// </summary>
    public DateTime DateTime => rawEpoch.ToDateTime();

    /// <summary>
    /// Get a <see cref="TimeSpan"/> representation of the <see cref="LongEpochTime"/> instance
    /// </summary>
    public TimeSpan TimeSpan => rawEpoch.ToTimeSpan();

    /// <summary>
    /// Applies the given <see cref="TimeSpan"/> offset to the <see cref="LongEpochTime"/> instance
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> offset to apply</param>
    /// <returns>The updated <see cref="LongEpochTime"/> instance</returns>
    /// <remarks>
    ///  The method returns an updated <see cref="LongEpochTime"/> but also updates the calling instance
    /// </remarks>
    public LongEpochTime Add(TimeSpan timeSpan)
    {
        var newSpan = TimeSpan + timeSpan;
        rawEpoch = newSpan.ToLongEpochTimestamp();
        return this;
    }

#if NET6_0_OR_GREATER
    /// <summary>
    /// Applies the given <see cref="TimeOnly"/> offset to the <see cref="LongEpochTime"/> instance
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public LongEpochTime Add(TimeOnly time) => this;
#endif

    /// <summary>
    /// Implements the + operator between two <see cref="LongEpochTime"/> instances
    /// </summary>
    /// <param name="operator1">The augend</param>
    /// <param name="operator2">The addend</param>
    /// <returns>The sum of the two <see cref="LongEpochTime"/></returns>
    public static LongEpochTime operator +(LongEpochTime operator1, LongEpochTime operator2)
    {
        // todo: There is a open issue with long number overflow

        return new LongEpochTime(operator1.Epoch + operator2.Epoch);
    }

    /// <summary>
    /// Implements the - operator between two <see cref="LongEpochTime"/> instances
    /// </summary>
    /// <param name="operator1">The minuend</param>
    /// <param name="operator2">The subtrahend</param>
    /// <returns>The Difference between the two <see cref="LongEpochTime"/> instances</returns>
    public static LongEpochTime operator -(LongEpochTime operator1, LongEpochTime operator2)
    {
        //todo: There is a open issue with long number underflow

        return new LongEpochTime(operator1.Epoch - operator2.Epoch);
    }

    /// <inheritdoc/>
    public override int GetHashCode() => rawEpoch.GetHashCode();

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is LongEpochTime comparedEpoch && comparedEpoch.Epoch == Epoch;

    /// <inheritdoc/>
    public override string ToString() => Epoch.ToString();
}