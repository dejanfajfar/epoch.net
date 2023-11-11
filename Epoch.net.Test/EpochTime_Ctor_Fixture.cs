using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochTime_Ctor_Fixture
    {
        private const int ValidEpochTimestamp = 1449878400;
        private readonly DateTime ValidDateTime = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
        private readonly EpochTime ValidEpochTime = new EpochTime(ValidEpochTimestamp); 
        
        [TestMethod]
        public void Int()
        {
            Assert.AreEqual(0, new EpochTime(0).Epoch);
            
            Assert.AreEqual(EpochTime.MAX_VALUE, EpochTime.MAX.Epoch);
            Assert.AreEqual(EpochTime.MIN_VALUE, EpochTime.MIN.Epoch);

            Assert.AreEqual(EpochTime.MIN, new EpochTime(EpochTime.MIN_VALUE));
            Assert.AreEqual(EpochTime.MAX, new EpochTime(EpochTime.MAX_VALUE));
        }

        [TestMethod]
        public void DateTime()
        {
            Assert.AreEqual(0, new EpochTime(0).Epoch);
            Assert.AreEqual(0, EpochTime.Default.Epoch);
            Assert.AreEqual(ValidEpochTimestamp, new EpochTime(ValidDateTime).Epoch);
            Assert.AreEqual(EpochTime.MIN, new EpochTime(EpochTime.MIN_DATETIME));
            Assert.AreEqual(EpochTime.MAX, new EpochTime(EpochTime.MAX_DATETIME));

            Assert.ThrowsException<EpochTimeValueException>(() =>
                new EpochTime(EpochTime.MAX_DATETIME.AddSeconds(1)));
            Assert.ThrowsException<EpochTimeValueException>(() =>
                new EpochTime(EpochTime.MIN_DATETIME.AddSeconds(-1)));
        }

        [TestMethod]
        public void EpochTime_Test()
        {
            Assert.AreEqual(ValidEpochTimestamp, new EpochTime(ValidEpochTime).Epoch);

            Assert.ThrowsException<ArgumentNullException>(() => new EpochTime(null));
        }
    }
}