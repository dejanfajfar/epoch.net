using System;

namespace Epoch.net
{
    public static class TimeSpanExtensions
    {
        public static EpochTime ToEpoch(this TimeSpan timeSpan)
        {
            return new EpochTime(timeSpan.ToRawEpoch());
        }

        public static decimal ToRawEpoch(this TimeSpan timeSpan)
        {
            var seconds = timeSpan.TotalSeconds;

            return Convert.ToDecimal(seconds);

            throw new EpochOverflowException(seconds.ToString());
        }

        public static int ToShortEpoch(this TimeSpan timeSpan)
        {
            return 1;
        }
    }
}