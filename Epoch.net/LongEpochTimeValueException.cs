using System;

namespace Epoch.net
{
    public class LongEpochTimeValueException : Exception
    {
        private const string TimeSpanErrorMessage = "";
        
        public LongEpochTimeValueException(TimeSpan value)
            :base(string.Format(TimeSpanErrorMessage, value))
        {
        }
    }
}