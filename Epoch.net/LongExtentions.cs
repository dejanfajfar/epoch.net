using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements extention methods to convert long numbers into DateTime objects
    /// </summary>
    public static class LongExtentions
    {
        public static DateTime AsDateTime(this long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }
    }
}