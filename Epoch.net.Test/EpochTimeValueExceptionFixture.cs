using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochTimeValueExceptionFixture
    {
        [TestMethod]
        public void ErrorMessageCorrect()
        {
            StringAssert.Contains(new EpochTimeValueException(DateTime.MinValue).Message, "The DateTime");
            Assert.AreEqual("The Timespan 00:00:00 is not in a Epoch range", new EpochTimeValueException(TimeSpan.Zero).Message);
            Assert.AreEqual("Message", new EpochTimeValueException("Message").Message);
            Assert.AreEqual("The number 1000 is not in a Epoch range", new EpochTimeValueException(1000L).Message);
        }
    }
}