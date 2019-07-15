using System;

namespace Epoch.net
{
    public static class IntExtensions
    {
        public static DateTime ToDateTime(this int epoch)
        {
            return Constants.UnixEpoch.AddSeconds(epoch);
        }

        public static TimeSpan ToTimeSpan(this int epoch)
        {
            return TimeSpan.FromSeconds(epoch);
        }

        public static EpochTime ToEpochTime(this int epoch)
        {
            return new EpochTime(epoch);
        }

        public static LongEpochTime ToLongEpochTime(this int epoch)
        {
            return new LongEpochTime(epoch.ToLongEpochTimestamp());
        }

        public static long ToLongEpochTimestamp(this int epoch)
        {
            return epoch * 1000L;
        }
    }
}