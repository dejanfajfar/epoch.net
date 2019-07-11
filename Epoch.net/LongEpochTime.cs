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
                throw new LongEpochTimeValueException(timeSpan);
            }

            rawEpoch = timeSpan.ToLongEpochTimestamp();
        }

        public LongEpochTime(LongEpochTime longEpochTime)
        {
            if (longEpochTime == null)
            {
                throw new ArgumentNullException(nameof(longEpochTime), "The provided LongEpochTime can not be null");
            }

            rawEpoch = longEpochTime.Epoch;
        }

        public LongEpochTime(EpochTime epochTime)
        {
            if (epochTime == null)
            {
                throw new ArgumentNullException(nameof(epochTime), "The provided EpochTime can not be null");
            }

            rawEpoch = epochTime.Epoch.ToLongEpochTimestamp();
        }

        private long rawEpoch { get; set; }

        public long Epoch => rawEpoch;

        public override int GetHashCode()
        {
            return rawEpoch.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is LongEpochTime comparedEpoch)
            {
                return comparedEpoch.Epoch == Epoch;
            }

            return false;
        }
    }
}