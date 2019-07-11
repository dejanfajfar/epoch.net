using System;

namespace Epoch.net
{
    public class EpochTimeValueException : Exception
    {
        private const string DefaultErrorMessage = "The provided value could not be represented in a Epoch";
        private const string DateTimeErrorMessage = "The DateTime {0} is not in a Epoch range";
        private const string TimeStampErrorMessage = "The Timespan {0} is not in a Epoch range";
        private const string EpochTimeErrorMessage = "The EpochTime {0} is not in a Epoch range";
        private const string LongErrorMessage = "{0}";

        
        
        public EpochTimeValueException()
            : base(DefaultErrorMessage){}
        
        public EpochTimeValueException(string message)
            :base(message) {}
            
        public EpochTimeValueException(DateTime value)
            :base(string.Format(DateTimeErrorMessage, value)){}

        public EpochTimeValueException(TimeSpan value)
            :base(string.Format(TimeStampErrorMessage, value)){}

        public EpochTimeValueException(EpochTime value)
            :base(string.Format(EpochTimeErrorMessage, value)){}

        public EpochTimeValueException(long value)
            :base(string.Format(LongErrorMessage, value)){}
    }
}