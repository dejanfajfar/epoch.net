using System;

namespace Epoch.net
{
    public sealed class LongEpochTime
    {
        public LongEpochTime(DateTime dateTime)
        {
            rawEpoch = dateTime.ToLongEpochTimestamp();
        }

        public LongEpochTime(long longEpochTimestamp)
        {
            rawEpoch = longEpochTimestamp;
        }

        public LongEpochTime(TimeSpan timeSpan)
        {
            if (!timeSpan.IsValidLongEpochTime())
            {
                throw new EpochValueException(timeSpan);
            }

            rawEpoch = timeSpan.ToLongEpochTimestamp();
        }

        private long rawEpoch { get; set; }

        public long Epoch => rawEpoch;
    }
}