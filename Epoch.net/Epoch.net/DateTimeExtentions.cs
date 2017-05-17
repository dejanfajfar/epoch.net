using System;

namespace Epoch.net
{
    public static class DateTimeExtentions
    {
        public static int ToEpoch(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (int) timeSinceDisco.TotalSeconds;
        }
    }
}