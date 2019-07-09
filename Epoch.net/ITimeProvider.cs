using System;

namespace Epoch.net
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}