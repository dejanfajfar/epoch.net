using System;

namespace Epoch.net;

public class DefaultTimeProvider : ITimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}