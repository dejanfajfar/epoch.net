using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTime_Properties_Fixture
    {
        private const long ValidLongEpochTimestamp = 1563178753368;
        private readonly DateTime ValidDateTime = new DateTime(2019, 7, 15, 8, 19, 13, 368, DateTimeKind.Utc);
        private LongEpochTime ValidLongEpochTime;
        private readonly TimeSpan ValidTimeSpan = System.TimeSpan.FromMilliseconds(ValidLongEpochTimestamp);

        [TestInitialize]
        public void SetUp()
        {
            ValidLongEpochTime = new LongEpochTime(ValidLongEpochTimestamp);
        }
        
        [TestMethod]
        public void DateTime()
        {
            Assert.AreEqual(ValidDateTime, ValidLongEpochTime.DateTime);
        }

        [TestMethod]
        public void TimeSpan()
        {
            Assert.AreEqual(ValidTimeSpan, ValidLongEpochTime.TimeSpan);
        }

        [TestMethod]
        public void Add_Zero()
        {
            Assert.AreEqual(ValidLongEpochTimestamp, ValidLongEpochTime.Add(System.TimeSpan.Zero).Epoch);
        }

        [TestMethod]
        public void Add_Positive()
        {
            Assert.AreEqual(ValidLongEpochTimestamp + 1, ValidLongEpochTime.Add(System.TimeSpan.FromMilliseconds(1)).Epoch);
        }

        [TestMethod]
        public void Add_Negative()
        {
            Assert.AreEqual(ValidLongEpochTimestamp - 1, ValidLongEpochTime.Add(System.TimeSpan.FromMilliseconds(-1)).Epoch);
        }
    }
}