using System;

namespace Epoch.net;

/// <summary>
/// Denotes the error state of a <see cref="LongEpochTime"/>
/// </summary>
public class LongEpochTimeValueException : Exception
{
    private const string TimeSpanErrorMessage = "The provided TimeSpan {0} does not conform to the LongEpochTime range";

    /// <summary>
    /// Creates a new instance of the <see cref="LongEpochTimeValueException"/> with the given <see cref="TimeSpan"/>
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan"/> that is not inside the valid <see cref="LongEpochTime"/> range</param>
    /// <remarks>
    /// It is assumed that the <see cref="TimeSpan"/> is not in a valid <see cref="LongEpochTime"/> value range
    /// </remarks>
    public LongEpochTimeValueException(TimeSpan value)
        : base(string.Format(TimeSpanErrorMessage, value))
    {
    }
}