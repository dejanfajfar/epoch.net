using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongExtensionsFixture
    {
        private const long MinValidNumber = int.MinValue;
        private const long MaxValidNumber = int.MaxValue;
        private readonly DateTime PositiveDateTime = new DateTime(2015, 5, 6, 10, 25, 55, 255, DateTimeKind.Utc);
        private const long PositiveLongEpochTimestamp = 1430907955255;
        private const long NegativeLongEpochTimestamp = -1430907955255;
        private readonly DateTime NegativeDateTime = new DateTime(1924, 8, 28, 13, 34, 4, 745, DateTimeKind.Utc);

        [TestMethod]
        public void IsValidEpochTimestamp()
        {
            Assert.IsTrue(MinValidNumber.IsValidEpochTimestamp());
            Assert.IsTrue(MaxValidNumber.IsValidEpochTimestamp());
            
            Assert.IsFalse((MaxValidNumber + 1).IsValidEpochTimestamp());
            Assert.IsFalse((MinValidNumber - 1).IsValidEpochTimestamp());
        }

        [TestMethod]
        public void ToDateTime()
        {
            Assert.AreEqual(Constants.UnixEpoch, 0l.ToDateTime());
            
            Assert.AreEqual(PositiveDateTime, PositiveLongEpochTimestamp.ToDateTime());
            Assert.AreEqual(NegativeDateTime, NegativeLongEpochTimestamp.ToDateTime());
        }

        [TestMethod]
        public void ToTimeSpan()
        {
            Assert.AreEqual(TimeSpan.Zero, 0l.ToTimeSpan());
            
            Assert.AreEqual(TimeSpan.FromMilliseconds(PositiveLongEpochTimestamp), PositiveLongEpochTimestamp.ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromMilliseconds(NegativeLongEpochTimestamp), NegativeLongEpochTimestamp.ToTimeSpan());
        }

        [TestMethod]
        public void ToEpochTimestamp()
        {
            Assert.AreEqual(0, 0l.ToEpochTimestamp());
            
            Assert.AreEqual(Constants.MAX_VALUE_INT, ((long)Constants.MAX_VALUE_INT * 1000).ToEpochTimestamp());
            Assert.AreEqual(Constants.MIN_VALUE_INT, ((long)Constants.MIN_VALUE_INT * 1000).ToEpochTimestamp());
            
            Assert.AreEqual(PositiveDateTime.ToEpochTimestamp(), PositiveLongEpochTimestamp.ToEpochTimestamp());

            Assert.ThrowsException<EpochTimeValueException>(() => ((long)Constants.MIN_VALUE_INT * 1000 - 1000).ToEpochTimestamp());
        }
    }
}