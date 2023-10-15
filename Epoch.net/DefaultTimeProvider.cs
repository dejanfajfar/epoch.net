using System;

namespace Epoch.net;

/// <summary>
/// Implemets the system default DateTimeProvider as defined in <seealso cref="IDateTimeProvider"/>
/// </summary>
public class DefaultTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}