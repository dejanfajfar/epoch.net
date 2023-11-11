using System;

namespace Epoch.net;

public static class Constants
{
    public static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    public const int MIN_VALUE_INT = -2147483648;
    public const int MAX_VALUE_INT = 2147483647;
    public static readonly DateTime MAX_VALUE_DATETIME = new(2038, 1, 19,3,14,07, DateTimeKind.Utc); // 3:14:07 Tuesday, 19 January 2038 UTC
    public static readonly DateTime MIN_VALUE_DATETIME = new(1901, 12, 13, 20, 45, 52, DateTimeKind.Utc); // 20:45:52 Friday, 13 December 1901 UTC
    public const long MAX_VALUE_LONG = 922337203685477;
    public const long MIN_VALUE_LONG = -922337203685477;
}