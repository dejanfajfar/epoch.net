using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class TimeSpanExtensionsFixture
    {
        [TestMethod]
        public void ToEpoch_OK()
        {
            var testObject = TimeSpan.FromSeconds(500);

            var testValue = testObject.ToEpoch();
            
            Assert.AreEqual(testValue, new EpochTime(500));
        }

        [TestMethod]
        public void ToRawEpoch_Ok()
        {
            var testObject = TimeSpan.FromSeconds(500);

            var testValue = testObject.ToRawEpoch();
            
            Assert.AreEqual(500, testValue);
        }
    }
}