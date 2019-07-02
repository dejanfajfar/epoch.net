using System;

namespace Epoch.net
{
    public static class DecimalExtensions
    {
        private static int WholePart(this decimal value)
        {
            var internalValue = value;
            return (int)decimal.Floor(internalValue);
        }

        private static int DecimalPart(this decimal value)
        {
            var truncatedValue = (value - Math.Truncate(value)) * 100;

            return (int) Math.Round(truncatedValue);
        }
        
        public static DateTime ToDateTime(this decimal value)
        {
            return value
                .WholePart()
                .ToDateTime()
                .AddMilliseconds((double)(value - Math.Truncate(value)) * 100);
        }

        public static TimeSpan ToTimeSpan(this decimal value)
        {
            return TimeSpan.Zero;
        }

        public static EpochTime ToEpoch(this decimal value)
        {
            return new EpochTime(value);
        }
    }
}