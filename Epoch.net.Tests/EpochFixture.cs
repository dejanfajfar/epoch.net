using System;
using NUnit.Framework;

namespace Epoch.net.Tests
{
    [TestFixture]
    public class EpochFixture
    {
        [Test]
        public void ConvertToDateTime_Given_0_Then_01011970()
        {
            Assert.That(Epoch.ConvertFromEpoct(0), Is.EqualTo(new DateTime(1970, 1, 1, 0, 0, 0, 0)));
        }
    
        [TestCase(1970, 1, 1, 0, 0, 0)]
        [TestCase(1982, 10, 25, 10, 0, 0)]
        public void ConvertToDateTime_Tests(int year, int month, int day, int hour, int minute, int second)
        {
            var testDateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
            
            Assert.That(Epoch.ConvertToEpoch(testDateTime), Is.EqualTo(testDateTime.AsEpoch()));
            
            Assert.That(Epoch.ConvertFromEpoct(testDateTime.AsEpoch()), Is.EqualTo(testDateTime));
        }
    }
}