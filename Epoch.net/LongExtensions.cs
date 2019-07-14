using System;

namespace Epoch.net
{
    public static class LongExtensions
    {
        public static bool IsValidEpochTimestamp(this long epoch)
        {
            return epoch >= Constants.MIN_VALUE_INT && epoch <= Constants.MAX_VALUE_INT;
        }

        public static DateTime ToDateTime(this long value)
        {
            return Constants.UnixEpoch.AddMilliseconds(value);
        }

        public static TimeSpan ToTimeSpan(this long value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        public static int ToEpochTimestamp(this long value)
        {
            var seconds = value / 1000;

            if (seconds.IsValidEpochTimestamp())
            {
                return Convert.ToInt32(seconds);
            }
            
            throw new EpochTimeValueException(value);
        }

        public static LongEpochTime ToLongEpochTime(this long value)
        {
            return new LongEpochTime(value);
        }
    }
}