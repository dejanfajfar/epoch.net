using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements a millisecond precise 
    /// </summary>
    public sealed class LongEpochTime
    {
        private static ITimeProvider timeProvider;

        static LongEpochTime()
        {
            timeProvider = new DefaultTimeProvider();            
        }
        
        #region Constructors
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
        
        #endregion

        private long rawEpoch { get; set; }
        
        #region Static methods

        public static void SetTimeProvider(ITimeProvider timeProvider)
        {
            if (timeProvider != null)
            {
                LongEpochTime.timeProvider = timeProvider;
            }
        }

        public static void ResetTimeProvider()
        {
            timeProvider = new DefaultTimeProvider();
        }

        public static LongEpochTime Now => timeProvider.UtcNow.ToLongEpochTime();

        #endregion
        
        #region Public methods
        
        public long Epoch => rawEpoch;

        public DateTime DateTime => rawEpoch.ToDateTime();

        public TimeSpan TimeSpan => rawEpoch.ToTimeSpan();

        public LongEpochTime Add(TimeSpan timeSpan)
        {
            var newSpan = TimeSpan + timeSpan;
            rawEpoch = newSpan.ToLongEpochTimestamp();
            return this;
        }

        #endregion
        
        #region Operators

        public static LongEpochTime operator +(LongEpochTime operator1, LongEpochTime operator2)
        {
            // todo: There is a open issue with long number overflow
            
            return new LongEpochTime(operator1.Epoch + operator2.Epoch);
        }

        public static LongEpochTime operator -(LongEpochTime operator1, LongEpochTime operator2)
        {
            //todo: There is a open issue with long number underflow
            
            return new LongEpochTime(operator1.Epoch - operator2.Epoch);
        }
        
        #endregion
        
        #region Overriden methods
        
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
        
        #endregion
    }
}