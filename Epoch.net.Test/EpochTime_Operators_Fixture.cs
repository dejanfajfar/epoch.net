using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    [TestCategory("EpochTime")]
    public class EpochTime_Operators_Fixture
    {
        private readonly EpochTime Valid_EpochTime = new EpochTime(500);
        private readonly EpochTime Max_EpochTime = new EpochTime(Constants.MAX_VALUE_INT);
        private readonly EpochTime Min_EpochTime = new EpochTime(Constants.MIN_VALUE_INT);
        
        [TestMethod]
        public void Addition()
        {   
            Assert.AreEqual(1000.ToEpochTime(), Valid_EpochTime + Valid_EpochTime);

            // Adding over the integer range throws an Exception
            Assert.ThrowsException<EpochTimeValueException>(() => Max_EpochTime + Valid_EpochTime);
        }

        [TestMethod]
        public void Substration()
        {
            Assert.AreEqual(Valid_EpochTime, 1000.ToEpochTime() - Valid_EpochTime);
            
            // Subtracting over the integer range throws an Exception
            Assert.ThrowsException<EpochTimeValueException>(() => Min_EpochTime - Valid_EpochTime);
        }
    }
}