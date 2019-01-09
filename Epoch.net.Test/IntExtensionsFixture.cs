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

        [TestMethod]
        public void ToDateTime_Before1970_Utc()
        {
            var testValue = (-285724800).ToDateTime();

            var expectedValue = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc);

            Assert.AreEqual(testValue, expectedValue);
        }
    }
}