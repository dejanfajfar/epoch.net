using System;

namespace Epoch.net
{
    public static class DateOnlyExtensions
    {
        public static EpochTime ToEpochTime(this DateOnly date) => date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc).ToEpochTime();

        public static EpochTime ToEpoctTime(this DateOnly date, TimeOnly time) => date.ToDateTime(time).ToEpochTime();
    }
}
