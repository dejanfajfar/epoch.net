using System;
using Epoch.net.Exceptions;

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

        public static bool IsValid(decimal value)
        {
            return value >= Constants.MIN_VALUE_INT && value <= Constants.MAX_VALUE_INT;
        }

        public static void Validate(int value)
        {
            // Every int32 value is a valid unix epoch
        }

        public static void Validate(DateTime value)
        {
            if (value <= Constants.MIN_VALUE_DATETIME)
            {
                throw new EpochUnderflowException(value);
            }

            if (value >= Constants.MAX_VALUE_DATETIME)
            {
                throw new EpochOverflowException(value);
            }
        }
    }
}