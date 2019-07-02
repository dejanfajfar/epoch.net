using System;

namespace Epoch.net.Exceptions
{
    public class EpochUnderflowException: EpochValueException
    {
        public EpochUnderflowException(string message)
            : base(message)
        {
            
        }

        public EpochUnderflowException(DateTime value)
            :base($"The given DateTime: ${value.ToLongDateString()} is to small to be an Epoch timestamp. Minimal value is ${Constants.MIN_VALUE_DATETIME.ToLongDateString()}")
        {
            
        }
    }
}