using System;

namespace Epoch.net
{
    /// <summary>
    /// Implemens utility methods on the <see cref="TimeOnly"/> structure 
    /// </summary>
    public static class TimeOnlyExtensions
    {
        public static LongEpochTime ToEpochTime(this TimeOnly time)
        {
            var foo = LongEpochTime.Default;

            return foo;
        }
    }
}
