using System;

namespace Epoch.net
{
    public static class EpochValidator
    {
        public static bool IsValid(int value)
        {
            // every int32 value is a valid unix epoch
            return true;
        }

        public static bool IsValid(DateTime value)
        {
            return Constants.MIN_VALUE_DATETIME <= value && value <= Constants.MAX_VALUE_DATETIME;
        }

        public static bool IsValid(TimeSpan value)
        {
            return value != null && IsValid(value.TotalSeconds);
        }

        public static bool IsValid(decimal value)
        {
            return value >= Constants.MIN_VALUE_INT && value < Constants.MAX_VALUE_INT + 1m;
        }

        public static bool IsValid(double value)
        {
            return IsValid(Convert.ToDecimal(value));
        }

        public static void Validate(int value)
        {
            // Every int32 value is a valid unix epoch
        }

        public static void Validate(TimeSpan value)
        {
            if (!IsValid(value))
            {
                throw new EpochValueException(value);
            }
        }

        public static void Validate(DateTime value)
        {
            if (!IsValid(value))
            {
                throw new EpochValueException(value);
            }
        }

        public static void Validate(EpochTime value)
        {
            if (value == null)
            {
                throw new EpochValueException(value);
            }
        }

        public static void Validate(double value)
        {
            if (!IsValid(value))
            {
                throw new EpochValueException(value);
            }
        }

        public static void Validate(decimal value)
        {
            if (!IsValid(value))
            {
                throw new EpochValueException(value);
            }
        }
    }
}