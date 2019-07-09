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


        public static void Validate(int value)
        {
            // Every int32 value is a valid unix epoch
        }

        public static void Validate(EpochTime value)
        {
            if (value == null)
            {
                throw new EpochValueException(value);
            }
        }
    }
}