using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class TimeSpanExtensionsFixture
    {
        private readonly TimeSpan Valid_TimeSpan = TimeSpan.FromSeconds(Valid_EpochTimestamp);
        private const int Valid_EpochTimestamp = 500;
        private const long Valid_LongEpochTimestamp = 500000;
        
        [TestMethod]
        public void ToEpochTime()
        {
            Assert.AreEqual(Valid_EpochTimestamp, Valid_TimeSpan.ToEpochTime().Epoch);
        }

        [TestMethod]
        public void ToEpochTimestamp()
        {
            Assert.AreEqual(Valid_EpochTimestamp, Valid_TimeSpan.ToEpochTimestamp());
        }

        [TestMethod]
        public void ToLongEpochTime()
        {
            Assert.AreEqual(Valid_LongEpochTimestamp, Valid_TimeSpan.ToLongEpochTime().Epoch);
        }

        [TestMethod]
        public void ToLongEpochTimestamp()
        {
            Assert.AreEqual(Valid_LongEpochTimestamp, Valid_TimeSpan.ToLongEpochTimestamp());
        }
        
        
    }
}