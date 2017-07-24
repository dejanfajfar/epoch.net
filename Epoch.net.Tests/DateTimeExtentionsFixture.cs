using System;
using NUnit.Framework;

namespace Epoch.net.Tests
{
    [TestFixture]
    public class DateTimeExtentionsFixture
    {
        [Test]
        public void AsEpoch_After1970_Utc_DateTime()
        {
            var epoch = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).AsEpoch();

            Assert.That(epoch, Is.EqualTo(1449878400));
        }

        [Test]
        public void AsEpoch_Before1970_Utc_DateTime()
        {
            var epoch = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc).AsEpoch();

            Assert.That(epoch, Is.EqualTo(-285724800));
        }
    }
}