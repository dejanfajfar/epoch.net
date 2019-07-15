using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochTime_Properties_Fixtures
    {
        private const int ValidEpochTimestamp = 1449878400;
        private readonly DateTime ValidDateTime = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        private EpochTime ValidEpochTime;
        private readonly TimeSpan ValidTimeSpan = System.TimeSpan.FromSeconds(ValidEpochTimestamp);

        [TestInitialize]
        public void TestSetup()
        {
            ValidEpochTime = new EpochTime(ValidEpochTimestamp);
        }

        [TestMethod]
        public void DateTime()
        {
            Assert.AreEqual(ValidDateTime, ValidEpochTime.DateTime);
        }

        [TestMethod]
        public void TimeSpan()
        {
            Assert.AreEqual(ValidTimeSpan, ValidEpochTime.TimeSpan);
        }

        [TestMethod]
        public void Add_Zero()
        {
            Assert.AreEqual(ValidEpochTimestamp, ValidEpochTime.Add(System.TimeSpan.Zero).Epoch);
        }

        [TestMethod]
        public void Add_Positive()
        {
            Assert.AreEqual(ValidEpochTimestamp + 1, ValidEpochTime.Add(System.TimeSpan.FromSeconds(1)).Epoch);
        }

        [TestMethod]
        public void Add_Negative()
        {
            Assert.AreEqual(ValidEpochTimestamp - 1, ValidEpochTime.Add(System.TimeSpan.FromSeconds(-1)).Epoch);
        }
    }
}