using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTime_Operators_Fixture
    {
        private readonly LongEpochTime Operand1 = new LongEpochTime(500L);
        private readonly LongEpochTime Operand2 = new LongEpochTime(300L);
        private readonly LongEpochTime AdditionResult = new LongEpochTime(800L);
        private readonly LongEpochTime SubstractionResult = new LongEpochTime(200L);
        
        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(AdditionResult, Operand1 + Operand2);
        }

        [TestMethod]
        public void Substraction()
        {
            Assert.AreEqual(SubstractionResult, Operand1 - Operand2);
        }
    }
}