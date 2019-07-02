using System;

namespace Epoch.net
{
    public static class DoubleExtensions
    {
        private static int WholePart(this double value)
        {
            var internalValue = (decimal) value;
            return (int)decimal.Floor(internalValue);
        }

        private static int DecimalPart(this double value)
        {
            var truncatedValue = (value - Math.Truncate(value)) * 100;

            return (int) Math.Round(truncatedValue);
        }
        
        public static DateTime ToDateTime(this double value)
        {
            return value
                .WholePart()
                .ToDateTime()
                .AddMilliseconds((value - Math.Truncate(value)) * 100);
        }

        public static TimeSpan ToTimeSpan(this double value)
        {
            return value
                .WholePart()
                .ToTimeSpan()
                .Add(new TimeSpan(0, 0, 0, 0, value.DecimalPart()));
        }

        public static EpochTime ToEpoch(this double value)
        {
            return new EpochTime(Convert.ToDecimal(value));
        }
    }
}