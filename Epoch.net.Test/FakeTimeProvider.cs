using System;

namespace Epoch.net.Test
{
    public class FakeTimeProvider : IDateTimeProvider
    {
        public const long LONG_EPOCH_TIMESTAMP = 1430906878051;
        public const int EPOCH_TIMESTAMP = 1430906878;

        public DateTime UtcNow => new DateTime(2015, 5, 6, 10, 7, 58, 51, DateTimeKind.Utc);
    }
}