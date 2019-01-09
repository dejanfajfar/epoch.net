using System;

namespace Epoch.net
{
    /// <summary>
    /// Implements and combines all Epoch helpers and provides the main entry point into the library
    /// </summary>
    /// <code>
    /// var epoch = Epoch.Now
    /// </code>
    public class Epoch
    {
        #region Constructors
        
        /// <summary>
        /// Creates a new instance of <see cref="Epoch"/> with a given rawEpoch
        /// </summary>
        /// <param name="rawEpoch">The number of seconds from 1970-01-01T00:00:00</param>
        public Epoch(int rawEpoch)
        {
            this.rawEpoch = rawEpoch;
        }
        
        /// <summary>
        /// Creates a new instance of <see cref="Epoch"/> with the given <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> used to initialize the <see cref="Epoch"/></param>
        /// <exception cref="ArgumentNullException">If the passed date time is null</exception>
        /// <remarks>
        ///    From the passed in DateTime only the UTC part is used
        /// </remarks>
        public Epoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            rawEpoch = dateTime.ToRawEpoch();
        }

        /// <summary>
        /// Creates a new instance of <see cref="Epoch"/> with the given <see cref="Epoch"/> instance as initilisation data
        /// </summary>
        /// <param name="epoch">Epoch used to initialize the instance</param>
        /// <exception cref="ArgumentNullException">If the epoch instance is null</exception>
        /// <remarks>
        /// Is a simple copy constructor
        /// </remarks>
        public Epoch(Epoch epoch)
        {
            if (epoch == null)
            {
                throw new ArgumentNullException(ErrorMessages.NullEpochGiven, nameof(epoch));
            }
            
            this.rawEpoch = epoch.ToRawEpoch();
        }
        #endregion

        private int rawEpoch;
        
        #region Static methods

        public static int NowRaw => DateTime.UtcNow.ToRawEpoch();

        public static Epoch Now => DateTime.UtcNow.ToEpoch();

        public static int ToRawEpoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            return dateTime.ToRawEpoch();
        }

        public static DateTime ToDateTime(int epoch)
        {
            return epoch.ToDateTime();
        }

        public static TimeSpan ToTimeSpan(int epoch)
        {
            return epoch.ToTimeSpan();
        }
        
        #endregion


        public int ToRawEpoch()
        {
            return rawEpoch;
        }

        public DateTime ToDateTime()
        {
            return rawEpoch.ToDateTime();
        }

        public TimeSpan ToTimeSpan()
        {
            return rawEpoch.ToTimeSpan();
        }
        
        #region Epoch manipulation

        public Epoch AddSeconds(int seconds)
        {
            rawEpoch += seconds;
            return this;
        }
        
        #endregion
        
        #region Operators

        public static Epoch operator +(Epoch operand1, Epoch operand2)
        {
            long epochSum = operand1.ToRawEpoch() + operand2.ToRawEpoch();

            if (int.TryParse(epochSum.ToString(), out int integerEpoch))
            {
                return new Epoch(integerEpoch);
            }
            
            throw new EpochOverflowException();
        }

        public static Epoch operator -(Epoch operand1, Epoch operand2)
        {
            return new Epoch(operand1.ToRawEpoch() - operand2.ToRawEpoch());
        }
        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            if (obj is Epoch comparedEpoch)
            {
                return comparedEpoch.rawEpoch == rawEpoch;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return rawEpoch;
        }

        #endregion
    }
}