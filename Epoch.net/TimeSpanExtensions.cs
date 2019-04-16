using System;

namespace Epoch.net
{
    public static class TimeSpanExtensions
    {
        public static EpochTime ToEpoch(this TimeSpan timeSpan)
        {
            return new EpochTime(timeSpan.ToRawEpoch());
        }

        public static int ToRawEpoch(this TimeSpan timeSpan)
        {
            var seconds = timeSpan.TotalSeconds;

            if (int.TryParse(seconds.ToString(), out int normalizedSeconds))
            {
                return normalizedSeconds;
            }
            
            throw new EpochOverflowException(seconds.ToString());
        }
    }
}