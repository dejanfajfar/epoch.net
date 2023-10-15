using System;

namespace Epoch.net.Test
{
    internal static class TestConstants
    {
        public static readonly DateTime After1970_UTC = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        public static readonly DateTime Before1970_UTC = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        public static readonly DateTime After1970 = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Local);
        public static readonly DateTime Before1970 = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Local);
        public static readonly DateTime OutOfBounds = new DateTime(2099, 7, 4, 0, 0, 0, DateTimeKind.Utc);
        public static readonly int After1970_UTC_Timestamp = 1449878400;
        public static readonly long After1970_UTC_LongTimestamp = 1449878400000;
        public static readonly int Before1970_UTC_Timestamp = -285724800;
        public static readonly long Before1970_UTC_LongTimestamp = -285724800000;
    }
}
