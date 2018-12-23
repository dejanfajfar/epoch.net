using System;

namespace Epoch.net
{
    public static class DateTimeExtensions
    {
        public static int ToRawEpoch(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (int) timeSinceDisco.TotalSeconds;
        }

        public static Epoch ToEpoch(this DateTime dateTime)
        {
            return new Epoch(dateTime.ToUniversalTime().ToRawEpoch());
        }
    }
}