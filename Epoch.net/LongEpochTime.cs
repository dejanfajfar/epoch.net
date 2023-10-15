using System;

namespace Epoch.net;

/// <summary>
/// Implements a millisecond precise unix epoch
/// </summary>
public sealed class LongEpochTime
{
    private static IDateTimeProvider timeProvider;

    static LongEpochTime()
    {
        timeProvider = new DefaultTimeProvider();            
    }
    
    #region Constructors
    
    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> from which to initialize the instance</param>
    public LongEpochTime(DateTime dateTime)
    {
        rawEpoch = dateTime.ToLongEpochTimestamp();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="LongEpochTime"/>
    /// </summary>
    /// <param name="longEpochTimestamp">The number of milliseconds since 1970-01-01T00:00Z</param>
    public LongEpochTime(long longEpochTimestamp)
    {
        rawEpoch = longEpochTimestamp;
    }

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
    
    #endregion

    private long rawEpoch { get; set; }
    
    #region Static methods

    /// <summary>
    /// Injects a new global thread safe <see cref="TimeProvider"/> instance to be used globally
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
    public static void ResetTimeProvider()
    {
        timeProvider = new DefaultTimeProvider();
    }

    /// <summary>
    /// Gets the current UTC date and time as an <see cref="LongEpochTime"/>
    /// </summary>
    public static LongEpochTime Now => timeProvider.UtcNow.ToLongEpochTime();

    #endregion
    
    #region Public methods
    
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

    #endregion
    
    #region Operators

    public static LongEpochTime operator +(LongEpochTime operator1, LongEpochTime operator2)
    {
        // todo: There is a open issue with long number overflow
        
        return new LongEpochTime(operator1.Epoch + operator2.Epoch);
    }

    public static LongEpochTime operator -(LongEpochTime operator1, LongEpochTime operator2)
    {
        //todo: There is a open issue with long number underflow
        
        return new LongEpochTime(operator1.Epoch - operator2.Epoch);
    }
    
    #endregion
    
    #region Overriden methods
    
    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return rawEpoch.GetHashCode();
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        if (obj is LongEpochTime comparedEpoch)
        {
            return comparedEpoch.Epoch == Epoch;
        }

        return false;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Epoch.ToString();
    }

    #endregion
}