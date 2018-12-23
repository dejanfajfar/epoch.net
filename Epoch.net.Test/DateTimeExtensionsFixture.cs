using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class DateTimeExtensionsFixture
    {
        [TestMethod]
        public void ToRawEpoch_After1970_Utc_DateTime()
        {
            var epoch = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch();

            Assert.AreEqual(1449878400, epoch);
        }
        
        [TestMethod]
        public void ToRawEpoch_After1970_DateTime()
        {
            var testDate = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Local);
            var offset = TimeZoneInfo.Local.GetUtcOffset(testDate).ToEpoch().ToRawEpoch();
            
            
            Assert.AreEqual(1449878400, testDate.ToRawEpoch() + offset);
        }
        
        [TestMethod]
        public void ToRawEpoch_Before1970_Utc_DateTime()
        {
            var epoch = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch();

            Assert.AreEqual(-285724800, epoch);
        }
        
        [TestMethod]
        public void ToRawEpoch_Before1970_DateTime()
        {
            var testDate = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Local);
            var offset = TimeZoneInfo.Local.GetUtcOffset(testDate).ToEpoch().ToRawEpoch();

            Assert.AreEqual(-285724800, testDate.ToRawEpoch() + offset);
        }
    }
}