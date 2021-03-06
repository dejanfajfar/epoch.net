using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochTime_Static_Fixture
    {
        [TestInitialize]
        public void SetUp()
        {
            EpochTime.SetTimeProvider(new FakeTimeProvider());
        }

        [TestCleanup]
        public void TearDown()
        {
            EpochTime.ResetTimeProvider();
        }

        [TestMethod]
        public void Now()
        {
            Assert.AreEqual(FakeTimeProvider.EPOCH_TIMESTAMP, EpochTime.Now.Epoch);
        }
    }
}