using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class IntExtensionsFixture
    {
        [TestMethod]
        public void ToDateTime_After1970_Utc()
        {
            var testValue = 1449878400.ToDateTime();

            var expectedValue = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc);
            
            Assert.AreEqual(testValue, expectedValue);
        }
    }
}