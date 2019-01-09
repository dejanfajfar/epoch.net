using System;

namespace Epoch.net
{
    public class Epoch
    {
        #region Constructors
        
        public Epoch(int rawEpoch)
        {
            this.rawEpoch = rawEpoch;
        }
        
        public Epoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            rawEpoch = dateTime.ToRawEpoch();
        }

        public Epoch(Epoch epoch)
        {
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