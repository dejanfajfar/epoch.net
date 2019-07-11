using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class IntExtensionsFixture
    {
        private const int After_1970_EpochTimestamp = 1449878400;
        private const long After_1970_LongEpochTimestamp = 1449878400000;
        private readonly DateTime After_1970_DateTime = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        private const int Before_1970_EpochTimestamp = -285724800;
        private const long Before_1970_LongEpochTimestamp = -285724800000;
        private readonly DateTime Before_1970_DateTime = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        
        [TestMethod]
        public void ToDateTime()
        {
            Assert.AreEqual(After_1970_DateTime, After_1970_EpochTimestamp.ToDateTime());
            Assert.AreEqual(Before_1970_DateTime, Before_1970_EpochTimestamp.ToDateTime());
        }

        [TestMethod]
        public void ToTimeSpan()
        {
            Assert.AreEqual(TimeSpan.FromSeconds(After_1970_EpochTimestamp), After_1970_EpochTimestamp.ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromSeconds(Before_1970_EpochTimestamp), Before_1970_EpochTimestamp.ToTimeSpan());
        }

        [TestMethod]
        public void ToEpochTime()
        {
            Assert.AreEqual(new EpochTime(After_1970_DateTime), After_1970_EpochTimestamp.ToEpochTime());
            Assert.AreEqual(new EpochTime(Before_1970_DateTime), Before_1970_EpochTimestamp.ToEpochTime());
        }

        [TestMethod]
        public void ToLongEpochTime()
        {
            Assert.AreEqual(new LongEpochTime(After_1970_DateTime), After_1970_EpochTimestamp.ToLongEpochTime());
            Assert.AreEqual(new LongEpochTime(Before_1970_DateTime), Before_1970_EpochTimestamp.ToLongEpochTime());
        }

        [TestMethod]
        public void ToLongEpochTimestamp()
        {
            Assert.AreEqual(After_1970_LongEpochTimestamp, After_1970_EpochTimestamp.ToLongEpochTimestamp());
            Assert.AreEqual(Before_1970_LongEpochTimestamp, Before_1970_EpochTimestamp.ToLongEpochTimestamp());
        }
    }
}