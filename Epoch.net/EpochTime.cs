using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements and combines all EpochTime helpers and provides the main entry point into the library
    /// </summary>
    /// <code>
    /// var epoch = EpochTime.Now
    /// </code>
    public class EpochTime
    {
        #region Constructors
        
        /// <summary>
        /// Creates a new instance of <see cref="EpochTime"/> with a given rawEpoch
        /// </summary>
        /// <param name="rawEpoch">The number of seconds from 1970-01-01T00:00:00</param>
        public EpochTime(int rawEpoch)
        {
            this.rawEpoch = rawEpoch;
        }
        
        /// <summary>
        /// Creates a new instance of <see cref="EpochTime"/> with a given rawEpoch
        /// </summary>
        /// <param name="rawEpoch">The number of seconds from 1970-01-01T00:00:00</param>
        public EpochTime(decimal rawEpoch)
        {
            this.rawEpoch = rawEpoch;
        }

        public EpochTime(double rawEpoch)
        {
            this.rawEpoch = (decimal) rawEpoch;
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
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            rawEpoch = (decimal) dateTime.ToRawEpoch();
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
            if (epoch == null)
            {
                throw new ArgumentNullException(ErrorMessages.NullEpochGiven, nameof(epoch));
            }
            
            this.rawEpoch = epoch.ToRawEpoch();
        }
        #endregion

        private decimal rawEpoch;
        
        #region Static methods

        /// <summary>
        /// Gets the current UTC date in an Epoch format
        /// </summary>
        public static decimal NowRaw => (decimal) DateTime.UtcNow.ToRawEpoch();

        /// <summary>
        /// Gets the current LOCAL date in an Epoch format
        /// </summary>
        public static EpochTime Now => DateTime.UtcNow.ToEpoch();

        /// <summary>
        /// Converts the given <see cref="DateTime"/> to an Epoch formatted integer
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> object to the converted</param>
        /// <returns>An integer representing the Epoch timestamp</returns>
        /// <exception cref="ArgumentNullException">
        /// If the passed <see cref="DateTime"/> is null then an <see cref="ArgumentNullException"/> is thrown
        /// </exception>
        /// <exception cref="EpochOverflowException">
        /// When the provided DateTime epoch representation is bigger than an integer
        /// </exception>
        public static decimal ToRawEpoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            return (decimal) dateTime.ToRawEpoch();
        }

        /// <summary>
        /// Converts the Epoch formatted <see cref="int"/> into a <see cref="DateTime"/>
        /// </summary>
        /// <param name="epoch">The epoch integer</param>
        /// <returns>A <see cref="DateTime"/> representing the date and time described in the epoch</returns>
        public static DateTime ToDateTime(int epoch)
        {
            return epoch.ToDateTime();
        }

        /// <summary>
        /// Converts the Epoch formatted <see cref="int"/> into a <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="epoch">The epoch integer</param>
        /// <returns>A <see cref="TimeSpan"/> representing the timespan described in the epoch</returns>
        public static TimeSpan ToTimeSpan(int epoch)
        {
            return epoch.ToTimeSpan();
        }
        
        #endregion


        /// <summary>
        /// Returns a <see cref="decimal"/> representation of the EpochTime object
        /// </summary>
        /// <returns>The unix timestamp</returns>
        [Obsolete("This method is deprecated, use the RawEpoch property")]
        public decimal ToRawEpoch()
        {
            return rawEpoch;
        }

        /// <summary>
        /// Returns a <see cref="decimal"/> representation of the EpochTime object
        /// </summary>
        /// <returns>The unix timestamp</returns>
        public decimal RawEpoch => rawEpoch;

        /// <summary>
        /// Return a <see cref="int"/> representation of the EpochTime object
        /// </summary>
        /// <returns>The unix timestamp without milliseconds</returns>
        /// <remarks>This is a lustful transformation where the milliseconds are lost from the epoch timestamp</remarks>
        public int ShortEpoch => (int) rawEpoch;

        /// <summary>
        /// Returns a <see cref="DateTime"/> representation of the Epoch object
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representation of the Epoch object</returns>
        [Obsolete("This method is deprecated, use the DateTime property")]
        public DateTime ToDateTime()
        {
            return rawEpoch.ToDateTime();
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> representation of the Epoch object
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representation of the Epoch object</returns>
        public DateTime DateTime => RawEpoch.ToDateTime();

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> representation of the Epoch object
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representation of the Epoch object</returns>
        [Obsolete("This method is deprecated, use the TimeSpan property")]
        public TimeSpan ToTimeSpan()
        {
            return rawEpoch.ToTimeSpan();
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> representation of the EpochTime object
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> representation of the EpochTime object</returns>
        public TimeSpan TimeSpan => RawEpoch.ToTimeSpan();

        #region Epoch manipulation

        /// <summary>
        /// Adds the provided seconds to the value of the epoch
        /// </summary>
        /// <param name="seconds">The seconds to add</param>
        /// <returns>A reference to itself for chaining purposes</returns>
        /// <remarks>
        /// If the seconds value is negative then the seconds will be deducted from the Epoch
        /// </remarks>
        public EpochTime AddSeconds(int seconds)
        {
            rawEpoch += seconds;
            return this;
        }

        public EpochTime AddHours(int hours)
        {
            rawEpoch += hours * 3600;
            return this;
        }

        public EpochTime AddTimeSpan(TimeSpan span)
        {
            var newSpan = RawEpoch.ToTimeSpan() + span;
            this.rawEpoch = newSpan.ToRawEpoch();
            return this;
        }
        
        #endregion
        
        #region Operators

        public static EpochTime operator +(EpochTime operand1, EpochTime operand2)
        {
            var epochSum = operand1.RawEpoch + operand2.RawEpoch;

            if (int.TryParse(epochSum.ToString(), out int integerEpoch))
            {
                return new EpochTime(integerEpoch);
            }
            
            throw new EpochOverflowException();
        }

        public static EpochTime operator -(EpochTime operand1, EpochTime operand2)
        {
            return new EpochTime(operand1.RawEpoch - operand2.RawEpoch);
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            if (obj is EpochTime comparedEpoch)
            {
                return comparedEpoch.RawEpoch == RawEpoch;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int) RawEpoch;
        }

        #endregion
    }
}