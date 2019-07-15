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
            
            Assert.AreEqual(Constants.MAX_VALUE_INT, new EpochTime(Constants.MAX_VALUE_INT).Epoch);
            Assert.AreEqual(Constants.MIN_VALUE_INT, new EpochTime(Constants.MIN_VALUE_INT).Epoch);
        }

        [TestMethod]
        public void DateTime()
        {
            Assert.AreEqual(0, new EpochTime(0).Epoch);
            Assert.AreEqual(ValidEpochTimestamp, new EpochTime(ValidDateTime).Epoch);
            Assert.AreEqual(Constants.MIN_VALUE_INT, new EpochTime(Constants.MIN_VALUE_DATETIME).Epoch);
            Assert.AreEqual(Constants.MAX_VALUE_INT, new EpochTime(Constants.MAX_VALUE_DATETIME).Epoch);

            Assert.ThrowsException<EpochTimeValueException>(() =>
                new EpochTime(Constants.MAX_VALUE_DATETIME.AddSeconds(1)));
            Assert.ThrowsException<EpochTimeValueException>(() =>
                new EpochTime(Constants.MIN_VALUE_DATETIME.AddSeconds(-1)));
        }

        [TestMethod]
        public void EpochTime()
        {
            Assert.AreEqual(ValidEpochTimestamp, new EpochTime(ValidEpochTime).Epoch);

            Assert.ThrowsException<ArgumentNullException>(() => new EpochTime(null));
        }
    }
}