using System;

namespace Epoch.net;

public class LongEpochTimeValueException : Exception
{
    private const string TimeSpanErrorMessage = "The provided TimeSpan {0} does not conform to the LongEpochTime range";
    
    public LongEpochTimeValueException(TimeSpan value)
        :base(string.Format(TimeSpanErrorMessage, value))
    {
    }
}