namespace Epoch.net
{
    public static class LongExtensions
    {
        public static bool IsValidEpochTimestamp(this long epoch)
        {
            return epoch > int.MinValue && epoch < int.MaxValue;
        }
    }
}