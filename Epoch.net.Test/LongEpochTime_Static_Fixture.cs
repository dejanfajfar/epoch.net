using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTime_Static_Fixture
    {
        [TestInitialize]
        public void SetUp()
        {
            LongEpochTime.SetTimeProvider(new FakeTimeProvider());
        }

        [TestCleanup]
        public void TearDown()
        {
            LongEpochTime.ResetTimeProvider();
        }
        
        [TestMethod]
        public void Now()
        {
            Assert.AreEqual(FakeTimeProvider.LONG_EPOCH_TIMESTAMP, LongEpochTime.Now.Epoch);
        }
    }
}