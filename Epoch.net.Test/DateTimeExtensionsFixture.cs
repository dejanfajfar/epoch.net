using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class DateTimeExtensionsFixture
    {
        [TestMethod]
        public void AsEpoch_After1970_Utc_DateTime()
        {
            var epoch = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).AsEpoch();

            Assert.AreEqual(epoch, 1449878400);
        }
        
        [TestMethod]
        public void AsEpoch_Before1970_Utc_DateTime()
        {
            var epoch = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc).AsEpoch();

            Assert.AreEqual(epoch, -285724800);
        }
    }
}