using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochFixture
    {
        #region ctor

        [TestMethod]
        public void Ctor_positive_rawEpoch_OK()
        {
            var testObject = new Epoch(500);
            
            Assert.AreEqual(testObject.ToRawEpoch(), 500);
        }

        [TestMethod]
        public void Ctor_negative_rawEpoch_OK()
        {
            var testObject = new Epoch(-500);
            
            Assert.AreEqual(testObject.ToRawEpoch(), -500);
        }

        [TestMethod]
        public void Ctor_null_Exception()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Epoch(null));
        }

        [TestMethod]
        public void Ctor_DateTime_Utc_OK()
        {
            var dateTime = new DateTime(2015, 10,25, 0, 0, 0, DateTimeKind.Utc);
            
            var testObject = new Epoch(dateTime);
            
            Assert.AreEqual(dateTime, testObject.ToDateTime());
        }

        [TestMethod]
        public void Ctor_DateTime_OK()
        {
            var dateTime = new DateTime(2015, 10,25, 0, 0, 0, DateTimeKind.Local);
            
            var testObject = new Epoch(dateTime);
            
            Assert.AreEqual(dateTime.ToUniversalTime(), testObject.ToDateTime());
        }

        [TestMethod]
        public void Ctor_Epoch_OK()
        {
            var testEpoch = new Epoch(500);
            
            var testObject = new Epoch(testEpoch);
            
            Assert.AreEqual(testEpoch, testObject);
        }
        
        #endregion
    }
}