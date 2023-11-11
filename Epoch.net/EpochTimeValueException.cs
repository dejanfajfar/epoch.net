using System;

namespace Epoch.net;

/// <summary>
/// Denotes the error state of a <seealso cref="EpochTime"/>
/// </summary>
public class EpochTimeValueException : Exception
{
    private const string DefaultErrorMessage = "The provided value could not be represented in a Epoch";
    private const string DateTimeErrorMessage = "The DateTime {0} is not in a Epoch range";
    private const string TimeStampErrorMessage = "The Timespan {0} is not in a Epoch range";
    private const string EpochTimeErrorMessage = "The EpochTime {0} is not in a Epoch range";
    private const string LongErrorMessage = "The number {0} is not in a Epoch range";

    /// <summary>
    /// Creates a new instance of the <see cref="EpochTimeValueException"/>
    /// </summary>
    public EpochTimeValueException()
        : base(DefaultErrorMessage) { }

    /// <summary>
    /// Creates a new instance of the <see cref="EpochTimeValueException"/> with the given error message
    /// </summary>
    /// <param name="message">The Error message to assigne to the new instance of the <see cref="EpochTimeValueException"/></param>
    public EpochTimeValueException(string message)
        : base(message) { }

    /// <summary>
    /// Creates a new instance of the <see cref="EpochTimeValueException"/> with a given <see cref="DateTime"/>
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> that is not in a valid Epoch range</param>
    /// <remarks>
    /// It is assumed that the provided <see cref="DateTime"/> is not in a valid Epoch range.
    /// </remarks>
    public EpochTimeValueException(DateTime value)
        : base(string.Format(DateTimeErrorMessage, value)) { }

    /// <summary>
    /// Creates a new instance of the <see cref="EpochTimeValueException"/> with a given <see cref="TimeSpan"/>
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan"/> that is not in a valid Epoch range</param>
    /// <remarks>
    /// It is assumed that the <see cref="TimeSpan"/> is not in a valid Epoch range
    /// </remarks>
    public EpochTimeValueException(TimeSpan value)
        : base(string.Format(TimeStampErrorMessage, value)) { }

    /// <summary>
    /// Creates a new instance of the <see cref="EpochTimeValueException"/> with a given <see cref="long"/> value
    /// </summary>
    /// <param name="value">The <see cref="long"/> that is not in a valid Epoch range</param>
    /// <remarks>
    /// It is assumed that the <see cref="long"/> value is not in a valid Epoch range
    /// </remarks>
    public EpochTimeValueException(long value)
        : base(string.Format(LongErrorMessage, value)) { }
}