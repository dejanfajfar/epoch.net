namespace Epoch.net
{
    public static class ErrorMessages
    {
        public const string InvalidDateTime = "A NULL instance of DateTime was provided!";
        public const string EpochOverflow = "The epoch value can not be contained in an int32 variable";

        public const string EpochOverflowFormatter =
            "The value {0} can not be stored into a int32 and is therefore invalid for an epoch";
    }
}