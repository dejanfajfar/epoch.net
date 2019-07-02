using System;

namespace Epoch.net.Exceptions
{
    public class EpochOverflowException: EpochValueException
    {
        public EpochOverflowException()
        :base(ErrorMessages.EpochOverflow){}
        
        public EpochOverflowException(string epochRawValue)
        :base(string.Format(ErrorMessages.EpochOverflowFormatter, epochRawValue)){}

        public EpochOverflowException(DateTime value)
            :base($"The given DateTime: ${value.ToLongDateString()} is to big to be an Epoch timestamp. Maximal value is ${Constants.MAX_VALUE_DATETIME.ToLongDateString()}")
        {
            
        }
    }
}