using System;

namespace Epoch.net
{
    public static class EpochValidator
    {
        private const int MIN_VALUE_INT = -2147483648;
        private const int MAX_VALUE_INT = 2147483647;
        private static readonly DateTime MAX_VALUE_DATETIME = new DateTime(2038, 1, 13,3,14,07, DateTimeKind.Utc); // 3:14:07 Tuesday, 19 January 2038 UTC
        private static readonly DateTime MIN_VALUE_DATETIME = new DateTime(1901, 12, 13, 20, 45, 52, DateTimeKind.Utc); // 20:45:52 Friday, 13 December 1901 UTC

        public static bool isValid(int value)
        {
            return MIN_VALUE_INT <= value && value <= MAX_VALUE_INT;
        }

        public static bool isValid(DateTime value)
        {
            return MIN_VALUE_DATETIME <= value && value <= MAX_VALUE_DATETIME;
        }
    }
}