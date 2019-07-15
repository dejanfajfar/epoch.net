using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements utility methods on the <see cref="DateTime"/> structure
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Transforms the 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToLongEpochTimestamp(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
            
            return Convert.ToInt64(timeSinceDisco.TotalMilliseconds);
        }

        public static int ToEpochTimestamp(this DateTime dateTime)
        {
            if (!dateTime.IsValidEpochTime())
            {
                throw new EpochTimeValueException(dateTime);
            }
            
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - Constants.UnixEpoch;
            
            return Convert.ToInt32(timeSinceDisco.TotalSeconds);
        }

        public static EpochTime ToEpochTime(this DateTime dateTime)
        {
            if (!dateTime.IsValidEpochTime())
            {
                throw new EpochTimeValueException(dateTime);
            }
            
            return new EpochTime(dateTime);
        }

        public static LongEpochTime ToLongEpochTime(this DateTime dateTime)
        {
            return new LongEpochTime(dateTime);
        }

        public static bool IsValidEpochTime(this DateTime dateTime)
        {
            return dateTime >= Constants.MIN_VALUE_DATETIME && dateTime <= Constants.MAX_VALUE_DATETIME;
        }
    }
}