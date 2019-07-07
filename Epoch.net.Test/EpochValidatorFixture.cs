using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epoch.net.Test
{
    [TestClass]
    public class EpochValidatorFixture
    {
        [TestMethod]
        public void DateTime_isValid()
        {
            //todo: Refactor this unit test before 2038

            Assert.IsTrue(EpochValidator.IsValid(DateTime.Now));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MAX_VALUE_DATETIME));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MIN_VALUE_DATETIME));
            
            Assert.IsFalse(EpochValidator.IsValid(Constants.MIN_VALUE_DATETIME.AddMinutes(-1)));
            Assert.IsFalse(EpochValidator.IsValid(Constants.MAX_VALUE_DATETIME.AddMinutes(1)));
        }

        [TestMethod]
        public void DateTime_Valid()
        {
            Assert.ThrowsException<EpochValueException>(() =>
                {
                    EpochValidator.Validate(Constants.MIN_VALUE_DATETIME.AddMinutes(-1));
                });
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate(Constants.MAX_VALUE_DATETIME.AddMinutes(1));
            });
        }

        [TestMethod]
        public void TimeSpan_IsValid()
        {
            Assert.IsTrue(EpochValidator.IsValid(TimeSpan.Zero));
            
            Assert.IsFalse(EpochValidator.IsValid(TimeSpan.MaxValue));
            Assert.IsFalse(EpochValidator.IsValid(TimeSpan.MinValue));
        }

        [TestMethod]
        public void TimeSpan_Valid()
        {
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate(TimeSpan.MaxValue);
            });
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate(TimeSpan.MinValue);
            });
        }

        [TestMethod]
        public void Decimal_IsValid()
        {
            Assert.IsTrue(EpochValidator.IsValid((decimal) 0));
            Assert.IsTrue(EpochValidator.IsValid((decimal) Constants.MAX_VALUE_INT));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MAX_VALUE_INT + .99m));
            Assert.IsTrue(EpochValidator.IsValid((decimal) Constants.MIN_VALUE_INT));
            
            Assert.IsFalse(EpochValidator.IsValid((decimal) Constants.MAX_VALUE_INT + 1));
            Assert.IsFalse(EpochValidator.IsValid((decimal) Constants.MIN_VALUE_INT - 1));
        }

        [TestMethod]
        public void Decimal_Valid()
        {
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate((decimal) Constants.MIN_VALUE_INT - 1);
            });
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate((decimal) Constants.MAX_VALUE_INT + 1);
            });
        }
        
        [TestMethod]
        public void Double_IsValid()
        {
            Assert.IsTrue(EpochValidator.IsValid((double) 0));
            Assert.IsTrue(EpochValidator.IsValid((double) Constants.MAX_VALUE_INT));
            Assert.IsTrue(EpochValidator.IsValid(Constants.MAX_VALUE_INT + .99m));
            Assert.IsTrue(EpochValidator.IsValid((double) Constants.MIN_VALUE_INT));
            
            Assert.IsFalse(EpochValidator.IsValid((double) Constants.MAX_VALUE_INT + 1));
            Assert.IsFalse(EpochValidator.IsValid((double) Constants.MIN_VALUE_INT - 1));
        }

        [TestMethod]
        public void Double_Valid()
        {
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate((double) Constants.MIN_VALUE_INT - 1);
            });
            Assert.ThrowsException<EpochValueException>(() =>
            {
                EpochValidator.Validate((double) Constants.MAX_VALUE_INT + 1);
            });
        }
    }
}