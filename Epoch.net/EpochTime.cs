using System;

namespace Epoch.net;

/// <summary>
/// Implements a to the second precise unix timestamp
/// </summary>
public sealed class EpochTime
{
    static EpochTime()
    {
        TimeProvider = new DefaultTimeProvider();
    }

    /// <summary>
    /// Provides a new instance of a <see cref="EpochTime"/> with the maximal possible value
    /// </summary>
    public static EpochTime MAX => new EpochTime(MAX_VALUE);
    /// <summary>
    /// Provides a new instance of a <see cref="EpochTime"/> with the minimal possible value
    /// </summary>
    public static EpochTime MIN => new EpochTime(MIN_VALUE);
    /// <summary>
    /// The minimal raw epoch value
    /// </summary>
    public const int MIN_VALUE = -2147483648;
    /// <summary>
    /// The maximal raw epoch value
    /// </summary>
    public const int MAX_VALUE = 2147483647;
    /// <summary>
    /// The maximal <see cref="DateTime"/> value that a <see cref="EpochTime"/> can take
    /// </summary>
    public static readonly DateTime MAX_DATETIME = new(2038, 1, 19,3,14,07, DateTimeKind.Utc); // 3:14:07 Tuesday, 19 January 2038 UTC
    /// <summary>
    /// The minimal <see cref="DateTime"/> value that a <see cref="EpochTime"/> can take
    /// </summary>
    public static readonly DateTime MIN_DATETIME = new(1901, 12, 13, 20, 45, 52, DateTimeKind.Utc); // 20:45:52 Friday, 13 December 1901 UTC

    /// <summary>
    /// The default value of <see cref="LongEpochTime"/>
    /// </summary>
    /// <remarks>
    /// Thursday, January 1, 1970 12:00:00 AM GMT
    /// </remarks>
    public static EpochTime Default => new(0);

    private static IDateTimeProvider TimeProvider { get; set; }

    #region Constructors

    /// <summary>
    /// Creates a new instance of <see cref="EpochTime"/> with a given rawEpoch
    /// </summary>
    /// <param name="rawEpoch">The number of seconds from 1970-01-01T00:00:00</param>
    public EpochTime(int rawEpoch)
    {
        this.rawEpoch = rawEpoch;
    }

    /// <summary>
    /// Creates a new instance of <see cref="EpochTime"/> with the given <see cref="DateTime"/>
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> used to initialize the <see cref="EpochTime"/></param>
    /// <exception cref="ArgumentNullException">
    /// If the passed <see cref="DateTime"/> is outside of the valid Epoch range
    /// </exception>
    /// <remarks>
    ///    The given <see cref="DateTime"/> is converted to UTC according to the environment settings
    /// </remarks>
    public EpochTime(DateTime dateTime)
    {
        if (!dateTime.IsValidEpochTime())
        {
            throw new EpochTimeValueException(dateTime);
        }

        rawEpoch = dateTime.ToEpochTimestamp();
    }

    /// <summary>
    /// Creates a new instance of <see cref="EpochTime"/> with the given <see cref="EpochTime"/> instance as initialisation data
    /// </summary>
    /// <param name="epoch"><see cref="EpochTime"/> used to initialize the instance</param>
    /// <exception cref="ArgumentNullException">If the epoch instance is null</exception>
    /// <remarks>
    /// Is a simple copy constructor
    /// </remarks>
    public EpochTime(EpochTime epoch)
    {
        if (epoch == null)
        {
            throw new ArgumentNullException(nameof(epoch), "The provided epoch can not be null");
        }

        rawEpoch = epoch.Epoch;
    }

    /// <summary>
    /// Creates a new instance of <see cref="EpochTime"/> with the given <see cref="TimeSpan"/> as a offset from 1970-01-01T00:00Z
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> representing the offset from 1970-01-01T00:00Z</param>
    /// <exception cref="EpochTimeValueException">
    /// If the offset would put the <see cref="EpochTime"/> outside of the valid Epoch range
    /// </exception>
    public EpochTime(TimeSpan timeSpan)
    {
        if (!timeSpan.IsValidEpochTime())
        {
            throw new EpochTimeValueException(timeSpan);
        }

        rawEpoch = timeSpan.ToEpochTimestamp();
    }
    #endregion

    private int rawEpoch;

    #region Static methods

    /// <summary>
    /// Injects a new global thread safe <see cref="TimeProvider"/> instance to be used globally
    /// </summary>
    /// <param name="timeProvider">The new time provider instance</param>
    public static void SetTimeProvider(IDateTimeProvider timeProvider)
    {
        if (timeProvider != null)
        {
            TimeProvider = timeProvider;
        }
    }

    /// <summary>
    /// Resets the global time provider to the default system time provider 
    /// </summary>
    public static void ResetTimeProvider()
    {
        TimeProvider = new DefaultTimeProvider();
    }

    /// <summary>
    /// Gets the current UTC date and time as an <see cref="EpochTime"/>
    /// </summary>
    public static EpochTime Now => TimeProvider.UtcNow.ToEpochTime();


    #endregion


    /// <summary>
    /// Gets a <see cref="int"/> representation of the <see cref="EpochTime"/> instance
    /// </summary>
    public int Epoch => rawEpoch;

    /// <summary>
    /// Returns a <see cref="DateTime"/> representation of the <see cref="EpochTime"/> instance
    /// </summary>
    public DateTime DateTime => rawEpoch.ToDateTime();


    /// <summary>
    /// Returns a <see cref="TimeSpan"/> representation of the <see cref="EpochTime"/> instance
    /// </summary>
    public TimeSpan TimeSpan => rawEpoch.ToTimeSpan();

#if NET6_0_OR_GREATER
    /// <summary>
    /// Returns a <see cref="DateOnly"/> representation of the <see cref="EpochTime"/> instance
    /// </summary>
    public DateOnly DateOnly => DateOnly.FromDateTime(rawEpoch.ToDateTime());

    /// <summary>
    /// Returns a <see cref="TimeOnly"/> representation of the <see cref="EpochTime"/> instance
    /// </summary>
    public TimeOnly TimeOnly => TimeOnly.FromDateTime(rawEpoch.ToDateTime());

#endif

    #region Epoch manipulation

    /// <summary>
    /// Applies the given <see cref="TimeSpan"/> offset to the <see cref="EpochTime"/> instance
    /// </summary>
    /// <param name="span">The <see cref="TimeSpan"/> offset to apply</param>
    /// <returns>The updated <see cref="EpochTime"/> instance</returns>
    /// <remarks>
    ///  The method returns an updated <see cref="EpochTime"/> but also updates the calling instance
    /// </remarks>
    public EpochTime Add(TimeSpan span)
    {
        var newSpan = this.TimeSpan + span;
        rawEpoch = newSpan.ToEpochTimestamp();
        return this;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Implements the + operator between two <see cref="EpochTime"/> instances
    /// </summary>
    /// <param name="operand1">The augend</param>
    /// <param name="operand2">The addend</param>
    /// <returns>The sum of the two <see cref="EpochTime"/></returns>
    /// <exception cref="EpochTimeValueException">
    /// If the result is not a valid <see cref="EpochTime"/>
    /// </exception>
    public static EpochTime operator +(EpochTime operand1, EpochTime operand2)
    {
        var epochSum = operand1.Epoch + (long)operand2.Epoch;

        if (epochSum.IsValidEpochTimestamp() is false)
        {
            throw new EpochTimeValueException(epochSum);
        }

        return new EpochTime(Convert.ToInt32(epochSum));
    }

    /// <summary>
    /// Implements the - operator between two <see cref="EpochTime"/> instances
    /// </summary>
    /// <param name="operand1">The minuend</param>
    /// <param name="operand2">The subtrahend</param>
    /// <returns>The Difference between the two <see cref="EpochTime"/> instances</returns>
    /// <exception cref="EpochTimeValueException">
    /// If the result is not a valid <see cref="EpochTime"/></exception>
    public static EpochTime operator -(EpochTime operand1, EpochTime operand2)
    {
        var epochSub = operand1.Epoch - (long)operand2.Epoch;

        if (epochSub.IsValidEpochTimestamp() is false)
        {
            throw new EpochTimeValueException(epochSub);
        }

        return new EpochTime(operand1.Epoch - operand2.Epoch);
    }
    #endregion

    #region Equals

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        if (obj is EpochTime comparedEpoch)
        {
            return comparedEpoch.Epoch == Epoch;
        }

        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Epoch;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Epoch.ToString();
    }

    #endregion
}