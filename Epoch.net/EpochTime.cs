using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements and combines all EpochTime helpers and provides the main entry point into the library
    /// </summary>
    /// <code>
    /// var epoch = EpochTime.Now
    /// </code>
    public sealed class EpochTime
    {
        static EpochTime()
        {
            TimeProvider = new DefaultTimeProvider();
        }
        
        private static ITimeProvider TimeProvider { get; set; }
        
        #region Constructors
        
        /// <summary>
        /// Creates a new instance of <see cref="EpochTime"/> with a given rawEpoch
        /// </summary>
        /// <param name="rawEpoch">The number of seconds from 1970-01-01T00:00:00</param>
        public EpochTime(int rawEpoch)
        {
            EpochValidator.Validate(rawEpoch);
            
            this.rawEpoch = rawEpoch;
        }

        /// <summary>
        /// Creates a new instance of <see cref="EpochTime"/> with the given <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> used to initialize the <see cref="EpochTime"/></param>
        /// <exception cref="ArgumentNullException">If the passed date time is null</exception>
        /// <remarks>
        ///    From the passed in DateTime only the UTC part is used
        /// </remarks>
        public EpochTime(DateTime dateTime)
        {
            if (!dateTime.IsValidEpochTime())
            {
                throw new EpochValueException(dateTime);
            }

            rawEpoch = dateTime.ToEpochTimestamp();
        }

        /// <summary>
        /// Creates a new instance of <see cref="EpochTime"/> with the given <see cref="EpochTime"/> instance as initilisation data
        /// </summary>
        /// <param name="epoch">Epoch used to initialize the instance</param>
        /// <exception cref="ArgumentNullException">If the epoch instance is null</exception>
        /// <remarks>
        /// Is a simple copy constructor
        /// </remarks>
        public EpochTime(EpochTime epoch)
        {
            EpochValidator.Validate(epoch);
            
            rawEpoch = epoch.Epoch;
        }
        
        public EpochTime(TimeSpan timeSpan)
        {
            if (!timeSpan.IsValidEpochTime())
            {
                throw new EpochValueException(timeSpan);
            }

            rawEpoch = timeSpan.ToEpochTimestamp();
        }
        #endregion

        private int rawEpoch;

        #region Static methods

        /// <summary>
        /// Injects a new global thread safe <see cref="TimeProvider"/> instance to be used globally
        /// </summary>
        /// <param name="timeProvider">The new time provider instance</param>
        public static void SetTimeProvider(ITimeProvider timeProvider)
        {
            if (timeProvider != null)
            {
                TimeProvider = timeProvider;
            }
        }

        /// <summary>
        /// Resets the global time provider to the default system time provider 
        /// </summary>
        public static void ResetTimeProvider()
        {
            TimeProvider = new DefaultTimeProvider();
        }

        /// <summary>
        /// Gets the current LOCAL date in an Epoch format
        /// </summary>
        public static EpochTime Now => TimeProvider.UtcNow.ToEpoch();
        
        
        #endregion
        

        /// <summary>
        /// Returns a <see cref="decimal"/> representation of the EpochTime object
        /// </summary>
        /// <returns>The unix timestamp</returns>
        public int Epoch => rawEpoch;

        /// <summary>
        /// Returns a <see cref="DateTime"/> representation of the Epoch object
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representation of the Epoch object</returns>
        public DateTime DateTime => rawEpoch.ToDateTime();
        

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> representation of the EpochTime object
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representation of the EpochTime object</returns>
        public TimeSpan TimeSpan => rawEpoch.ToTimeSpan();

        #region Epoch manipulation

        public EpochTime Add(TimeSpan span)
        {
            var newSpan = this.TimeSpan + span;
            rawEpoch = newSpan.ToEpochTimestamp();
            return this;
        }
        
        #endregion
        
        #region Operators

        public static EpochTime operator +(EpochTime operand1, EpochTime operand2)
        {
            var epochSum = operand1.Epoch + operand2.Epoch;
            
            EpochValidator.Validate(epochSum);
            
            return new EpochTime(epochSum);
        }

        public static EpochTime operator -(EpochTime operand1, EpochTime operand2)
        {
            return new EpochTime(operand1.Epoch - operand2.Epoch);
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            if (obj is EpochTime comparedEpoch)
            {
                return comparedEpoch.Epoch == Epoch;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Epoch;
        }

        #endregion
    }
}