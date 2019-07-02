using System;
using Epoch.net.Exceptions;

namespace Epoch.net
{
    public static class TimeSpanExtensions
    {
        public static EpochTime ToEpoch(this TimeSpan timeSpan)
        {
            return new EpochTime(timeSpan.ToRawEpoch());
        }

        public static double ToRawEpoch(this TimeSpan timeSpan)
        {
            return timeSpan.TotalSeconds;
        }

        public static int ToShortEpoch(this TimeSpan timeSpan)
        {
            return 1;
        }
    }
}