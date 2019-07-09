using System;

namespace Epoch.net
{
    public class EpochValueException : Exception
    {
        private const string DefaultErrorMessage = "The provided value could not be represented in a Epoch";
        private const string DateTimeErrorMessage = "The DateTime {0} is not in a Epoch range";
        private const string TimeStampErrorMessage = "The Timespan {0} is not in a Epoch range";
        private const string EpochTimeErrorMessage = "The EpochTime {0} is not in a Epoch range";

        
        
        public EpochValueException()
            : base(DefaultErrorMessage){}
        
        public EpochValueException(string message)
            :base(message) {}
            
        public EpochValueException(DateTime value)
            :base(string.Format(DateTimeErrorMessage, value)){}

        public EpochValueException(TimeSpan value)
            :base(string.Format(TimeStampErrorMessage, value)){}

        public EpochValueException(EpochTime value)
            :base(string.Format(EpochTimeErrorMessage, value)){}
    }
}