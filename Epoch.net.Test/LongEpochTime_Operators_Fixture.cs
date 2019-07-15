using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class LongEpochTime_Operators_Fixture
    {
        private readonly LongEpochTime Operand1 = new LongEpochTime(500l);
        private readonly LongEpochTime Operand2 = new LongEpochTime(300l);
        private readonly LongEpochTime AdditionResult = new LongEpochTime(800l);
        private readonly LongEpochTime SubstractionResult = new LongEpochTime(200l);
        
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