using System;

namespace Epoch.net;

#if NET6_0_OR_GREATER
/// <summary>
/// Implemens utility methods on the <see cref="TimeOnly"/> structure 
/// </summary>
public static class TimeOnlyExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static LongEpochTime ToEpochTime(this TimeOnly time)
    {
        var foo = LongEpochTime.Default;

        return foo;
    }
}
#endif
