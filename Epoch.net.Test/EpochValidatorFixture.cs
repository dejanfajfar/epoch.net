using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochValidatorFixture
    {
        [TestMethod]
        public void Int_UpperBounds()
        {
            Assert.IsTrue(EpochValidator.isValid(Int32.MaxValue));
        }

        [TestMethod]
        public void Int_LowerBounds()
        {
            
        }
    }
}