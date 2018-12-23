using System;

namespace Epoch.net
{
    public static class TimeSpanExtensions
    {
        public static Epoch ToEpoch(this TimeSpan timeSpan)
        {
            return new Epoch(timeSpan.ToRawEpoch());
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