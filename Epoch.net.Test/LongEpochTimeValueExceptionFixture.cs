using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTimeValueExceptionFixture
    {
        [TestMethod]
        public void ErrorMessageCorrect()
        {
            Assert.AreEqual("The provided TimeSpan 00:00:00 does not conform to the LongEpochTime range", new LongEpochTimeValueException(TimeSpan.Zero).Message);
        }
    }
}