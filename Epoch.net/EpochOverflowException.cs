using System;

namespace Epoch.net
{
    public class EpochOverflowException: Exception
    {
        public EpochOverflowException()
        :base(ErrorMessages.EpochOverflow){}
        
        public EpochOverflowException(string epochRawValue)
        :base(string.Format(ErrorMessages.EpochOverflowFormatter, epochRawValue)){}
    }
}