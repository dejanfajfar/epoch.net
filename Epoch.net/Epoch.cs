using System;

namespace Epoch.net
{
    /// <summary>
    /// Representa an epoch timestamp and provides some additional helper methods
    /// </summary>
    public class Epoch
    {
        /// <summary>
        /// Creates a new instance of the Object with the predefined unix timestamp as its value
        /// </summary>
        /// <param name="epoch">THe unix timestamp representig this epoch instance</param>
        public Epoch(long epoch)
        {
            _epoch = epoch;
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Epoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            _epoch = dateTime.AsEpoch();
        }

        private long _epoch { get; }

        public static long Now => DateTime.UtcNow.AsEpoch();

        public static long ConvertToEpoch(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidDateTime, nameof(dateTime));
            }

            return dateTime.AsEpoch();
        }

        public static DateTime ConvertFromEpoct(long epoch)
        {
            return epoch.AsDateTime();
        }

        public long ToEpoch => _epoch;

        public DateTime ToDateTime => _epoch.AsDateTime();
    }
}