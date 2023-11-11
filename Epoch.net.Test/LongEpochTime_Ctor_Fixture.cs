using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTime_Ctor_Fixture
    {
        private const long ValidLongEpochTimestamp = 1563178753368;
        private readonly DateTime ValidDateTime = new DateTime(2019, 7, 15, 8, 19, 13, 368, DateTimeKind.Utc);
        private readonly LongEpochTime ValidLongEpochTime = new LongEpochTime(ValidLongEpochTimestamp);
        private readonly EpochTime ValidEpochTime = new EpochTime(ValidLongEpochTimestamp.ToEpochTimestamp());
        
        [TestMethod]
        public void Long()
        {
            Assert.AreEqual(0L, new LongEpochTime(0L).Epoch);

            Assert.AreEqual(LongEpochTime.Default, new LongEpochTime(LongEpochTime.DefaultDateTime));
            
            Assert.AreEqual(ValidLongEpochTimestamp, new LongEpochTime(ValidLongEpochTimestamp).Epoch);
        }

        [TestMethod]
        public void TimeSpan()
        {
            Assert.AreEqual(0L, new LongEpochTime(System.TimeSpan.Zero).Epoch);
            
            Assert.AreEqual(ValidLongEpochTimestamp, new LongEpochTime(System.TimeSpan.FromMilliseconds(ValidLongEpochTimestamp)).Epoch);

            Assert.AreEqual(LongEpochTime.MAX, new LongEpochTime(System.TimeSpan.MaxValue));
            Assert.AreEqual(LongEpochTime.MIN, new LongEpochTime(System.TimeSpan.MinValue));
        }

        [TestMethod]
        public void DateTime()
        {
            Assert.AreEqual(0L, LongEpochTime.Default.Epoch);
            
            Assert.AreEqual(ValidLongEpochTimestamp, new LongEpochTime(ValidDateTime).Epoch);
        }

        [TestMethod]
        public void LongEpochTimeTest()
        {
            Assert.AreEqual(ValidLongEpochTimestamp, new LongEpochTime(ValidLongEpochTime).Epoch);
        }

        [TestMethod]
        public void EpochTime()
        {
            Assert.AreEqual(1563178753000, new LongEpochTime(ValidEpochTime).Epoch);
        }
    }
}