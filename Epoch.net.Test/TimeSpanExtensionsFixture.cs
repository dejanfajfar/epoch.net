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

        [TestMethod]
        public void ToRawEpoch_WithDecimals_Ok()
        {
            var expectedValue = TimeSpan.FromSeconds(500.66);

            var actualValue = expectedValue.ToRawEpoch();
            
            Assert.AreEqual(500.66, actualValue, 0.00000001);
        }
    }
}