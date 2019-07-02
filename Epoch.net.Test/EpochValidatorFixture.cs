using System;
using Epoch.net.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochValidatorFixture
    {
        [TestMethod]
        public void DateTime_isValid_ValidData()
        {
            //todo: Refactor this unit test before 2038

            Assert.IsTrue(EpochValidator.IsValid(DateTime.Now));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MAX_VALUE_DATETIME));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MIN_VALUE_DATETIME));
        }

        [TestMethod]
        public void DateTime_IsValid_InvalidData()
        {
            Assert.IsFalse(EpochValidator.IsValid(Constants.MIN_VALUE_DATETIME.AddMinutes(-1)));
            Assert.IsFalse(EpochValidator.IsValid(Constants.MAX_VALUE_DATETIME.AddMinutes(1)));
        }

        [TestMethod]
        public void DateTime_Valid()
        {
            Assert.ThrowsException<EpochUnderflowException>(() =>
                {
                    EpochValidator.Validate(Constants.MIN_VALUE_DATETIME.AddMinutes(-1));
                });
            Assert.ThrowsException<EpochOverflowException>(() =>
            {
                EpochValidator.Validate(Constants.MAX_VALUE_DATETIME.AddMinutes(1));
            });
        }

        [TestMethod]
        public void Decimal_IsValid_ValidData()
        {
            Assert.IsTrue(EpochValidator.IsValid((decimal) 0));
            Assert.IsTrue(EpochValidator.IsValid((decimal) Constants.MAX_VALUE_INT));
            Assert.IsTrue(EpochValidator.IsValid((decimal) Constants.MIN_VALUE_INT));
        }

        [TestMethod]
        public void Decimal_IsValid_InvalidData()
        {
            Assert.IsFalse(EpochValidator.IsValid((decimal) Constants.MAX_VALUE_INT + 1));
            Assert.IsFalse(EpochValidator.IsValid((decimal) Constants.MIN_VALUE_INT - 1));
        }
    }
}