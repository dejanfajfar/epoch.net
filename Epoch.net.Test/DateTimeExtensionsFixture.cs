using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class DateTimeExtensionsFixture
    {
        private readonly DateTime After1970_UTC = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        private readonly DateTime Before1970_UTC = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        private readonly DateTime After1970 = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Local);
        private readonly DateTime Before1970 = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Local);
        private readonly DateTime OutOfBounds = new DateTime(2099, 7, 4, 0, 0, 0, DateTimeKind.Utc);
        private readonly int After1970_UTC_Timestamp = 1449878400;
        private readonly long After1970_UTC_LongTimestamp = 1449878400000;
        private readonly int Before1970_UTC_Timestamp = -285724800;
        private readonly long Before1970_UTC_LongTimestamp = -285724800000;
        
        [TestMethod]
        public void ToEpochTimestamp_UTC()
        {
            Assert.AreEqual(After1970_UTC_Timestamp, After1970_UTC.ToEpochTimestamp());
            Assert.AreEqual(Before1970_UTC_Timestamp, Before1970_UTC.ToEpochTimestamp());
            
            Assert.ThrowsException<EpochValueException>(
                () => OutOfBounds.ToEpochTimestamp());
        }
        
        [TestMethod]
        public void ToEpochTimestamp()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(After1970).ToEpochTime().Epoch;
            
            Assert.AreEqual(After1970_UTC_Timestamp, After1970.ToEpochTimestamp() + offset);
            Assert.AreEqual(Before1970_UTC_Timestamp, Before1970.ToEpochTimestamp() + offset);
        }

        [TestMethod]
        public void ToEpoch_UTC()
        {
            Assert.AreEqual(After1970_UTC_Timestamp, After1970_UTC.ToEpoch().Epoch);
            Assert.AreEqual(Before1970_UTC_Timestamp, Before1970_UTC.ToEpoch().Epoch);
        }

        [TestMethod]
        public void ToEpoch()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(After1970).ToEpochTime().Epoch;
            
            Assert.AreEqual(After1970_UTC_Timestamp, After1970.ToEpoch().Epoch + offset);
            Assert.AreEqual(Before1970_UTC_Timestamp, Before1970.ToEpoch().Epoch + offset);
        }

        [TestMethod]
        public void ToLongEpochTimestamp_UTC()
        {
            Assert.AreEqual(After1970_UTC_LongTimestamp, After1970_UTC.ToLongEpochTimestamp());
            Assert.AreEqual(Before1970_UTC_LongTimestamp, Before1970_UTC.ToLongEpochTimestamp());
        }

        [TestMethod]
        public void ToLongEpochTimestamp()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(After1970).ToLongEpochTime().Epoch;
            
            Assert.AreEqual(After1970_UTC_LongTimestamp, After1970.ToLongEpochTimestamp() + offset);
            Assert.AreEqual(Before1970_UTC_LongTimestamp, Before1970.ToLongEpochTimestamp() + offset);
        }
        
        [TestMethod]
        public void ToLongEpochTime_UTC()
        {
            Assert.AreEqual(After1970_UTC_LongTimestamp, After1970_UTC.ToLongEpochTime().Epoch);
            Assert.AreEqual(Before1970_UTC_LongTimestamp, Before1970_UTC.ToLongEpochTime().Epoch);
        }

        [TestMethod]
        public void ToLongEpochTime()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(After1970).ToLongEpochTime().Epoch;
            
            Assert.AreEqual(After1970_UTC_LongTimestamp, After1970.ToLongEpochTime().Epoch + offset);
            Assert.AreEqual(Before1970_UTC_LongTimestamp, Before1970.ToLongEpochTime().Epoch + offset);
        }
    }
}