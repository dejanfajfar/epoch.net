using System;

namespace Epoch.net
{
    public static class IntExtensions
    {
        public static DateTime ToDateTime(this int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }

        public static TimeSpan ToTimeSpan(this int epoch)
        {
            return TimeSpan.FromSeconds(epoch);
        }

        public static Epoch ToEpoch(this int epoch)
        {
            return new Epoch(epoch);
        }
    }
}