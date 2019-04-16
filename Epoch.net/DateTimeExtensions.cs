using System;

namespace Epoch.net
{
    public static class DateTimeExtensions
    {
        public static int ToRawEpoch(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            if (int.TryParse(timeSinceDisco.TotalSeconds.ToString(), out int rawEpoch))
            {
                return rawEpoch;
            }

            throw new EpochOverflowException();
        }

        public static EpochTime ToEpoch(this DateTime dateTime)
        {
            return new EpochTime(dateTime.ToUniversalTime().ToRawEpoch());
        }
    }
}