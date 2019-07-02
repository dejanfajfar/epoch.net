using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class DoubleExtensionsFixture
    {
        [TestMethod]
        public void AddingZeroWillProduce1970()
        {
            var expectedValue = Constants.UnixEpoch;

            var actualValue = ((double) 0).ToDateTime();
            
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void NoMillisecondsWillProduceCorrectTime()
        {
            var expectedValue = new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc);
            
            var actualValue = 1449878400.00.ToDateTime();
            
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void IfMillisecondsPresentThenCorrectlySet()
        {
            var expectedValue = new DateTime(2015, 12, 12, 0, 0, 0, 75, DateTimeKind.Utc);
            
            var actualValue = 1449878400.75.ToDateTime();
            
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ToTimeSpan_When0GivenThen0Returned()
        {
            Assert.AreEqual(new TimeSpan(0), ((double) 0).ToTimeSpan());
        }

        [TestMethod]
        public void ToTimeSpan_WorksWithoutProvidedMilliseconds()
        {
            var expectedValue = new TimeSpan(1, 1, 6);
            
            var actualValue = 3666.0.ToTimeSpan();
            
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        [TestMethod]
        public void ToTimeSpan_WorksWithProvidedMilliseconds()
        {
            var expectedValue = new TimeSpan(0,1, 1, 6, 66);
            
            var actualValue = 3666.66.ToTimeSpan();
            
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        
    }
}