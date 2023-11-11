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
            Assert.AreEqual(LongEpochTime.DefaultDateTime, 0L.ToDateTime());
            
            Assert.AreEqual(PositiveDateTime, PositiveLongEpochTimestamp.ToDateTime());
            Assert.AreEqual(NegativeDateTime, NegativeLongEpochTimestamp.ToDateTime());
        }

        [TestMethod]
        public void ToTimeSpan()
        {
            Assert.AreEqual(TimeSpan.Zero, 0L.ToTimeSpan());
            
            Assert.AreEqual(TimeSpan.FromMilliseconds(PositiveLongEpochTimestamp), PositiveLongEpochTimestamp.ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromMilliseconds(NegativeLongEpochTimestamp), NegativeLongEpochTimestamp.ToTimeSpan());
        }

        [TestMethod]
        public void ToEpochTimestamp()
        {
            Assert.AreEqual(0, 0L.ToEpochTimestamp());
            
            Assert.AreEqual(EpochTime.MAX_VALUE, ((long) EpochTime.MAX_VALUE * 1000).ToEpochTimestamp());
            Assert.AreEqual(EpochTime.MIN_VALUE, ((long)EpochTime.MIN_VALUE * 1000).ToEpochTimestamp());
            
            Assert.AreEqual(PositiveDateTime.ToEpochTimestamp(), PositiveLongEpochTimestamp.ToEpochTimestamp());

            Assert.ThrowsException<EpochTimeValueException>(() => ((long)EpochTime.MIN_VALUE * 1000 - 1000).ToEpochTimestamp());
        }
    }
}