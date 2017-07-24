using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements Extention methods to convert a DateTime to an Epoch
    /// </summary>
    public static class DateTimeExtentions
    {
        /// <summary>
        /// Converts the <see cref="DateTime"/> instance into an epoch integer
        /// </summary>
        /// <param name="dateTime">The DateTime instance to use</param>
        /// <returns>An integer representing the epoch integer</returns>
        public static long AsEpoch(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long) timeSinceDisco.TotalSeconds;
        }
    }
}