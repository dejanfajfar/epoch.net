using System;

namespace Epoch.net
{
    public static class TimeSpanExtensions
    {
        public static EpochTime ToEpochTime(this TimeSpan timeSpan)
        {
            return new EpochTime(timeSpan);
        }

        public static int ToEpochTimestamp(this TimeSpan timeSpan)
        {
            var totalSeconds = timeSpan.TotalSeconds;

            if (!timeSpan.IsValidEpochTime())
            {
                throw new EpochTimeValueException(timeSpan);
            }

            return Convert.ToInt32(totalSeconds);
        }

        public static LongEpochTime ToLongEpochTime(this TimeSpan timeSpan)
        {
            return new LongEpochTime(timeSpan);
        }

        public static long ToLongEpochTimestamp(this TimeSpan timeSpan)
        {
            var totalMilliseconds = timeSpan.TotalMilliseconds;

            if (!timeSpan.IsValidLongEpochTime())
            {
                throw new LongEpochTimeValueException(timeSpan);
            }

            return Convert.ToInt64(totalMilliseconds);
        }

        public static bool IsValidEpochTime(this TimeSpan timeSpan)
        {
            var totalSeconds = timeSpan.TotalSeconds;

            return totalSeconds >= Constants.MIN_VALUE_INT && totalSeconds <= Constants.MAX_VALUE_INT;
        }

        public static bool IsValidLongEpochTime(this TimeSpan timeSpan)
        {
            var totalMilliseconds = timeSpan.TotalMilliseconds;

            return totalMilliseconds >= long.MinValue && totalMilliseconds <= long.MaxValue;
        }
    }
}