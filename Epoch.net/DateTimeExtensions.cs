using System;

namespace Epoch.net
{
    public static class DateTimeExtensions
    {
        public static double ToRawEpoch(this DateTime dateTime)
        {
            if (!EpochValidator.isValid(dateTime))
            {
                throw new EpochOverflowException();
            }
                
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
            
            return timeSinceDisco.TotalSeconds;
        }

        public static EpochTime ToEpoch(this DateTime dateTime)
        {
            return new EpochTime(dateTime.ToUniversalTime().ToRawEpoch());
        }
    }
}