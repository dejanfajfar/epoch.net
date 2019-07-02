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

        public static EpochTime ToEpoch(this int epoch)
        {
            return new EpochTime(epoch);
        }
    }
}