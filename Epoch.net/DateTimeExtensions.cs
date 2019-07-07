using System;

namespace Epoch.net
{
    public static class DateTimeExtensions
    {
        public static double ToRawEpoch(this DateTime dateTime)
        {
            EpochValidator.Validate(dateTime);
                
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
            
            return timeSinceDisco.TotalSeconds;
        }

        public static int ToShortEpoch(this DateTime value)
        {
            EpochValidator.Validate(value);
            
            return value.ToRawEpoch().ToShortEpoch();
        }

        public static EpochTime ToEpoch(this DateTime dateTime)
        {
            EpochValidator.Validate(dateTime);
            
            return new EpochTime(dateTime.ToUniversalTime().ToRawEpoch());
        }
    }
}