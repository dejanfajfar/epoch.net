using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Epoch.net.Test
{
    [TestClass]
    public class DateOnlyExtensionsFitxture
    {
        private readonly DateOnly After1970_UTC = DateOnly.FromDateTime(TestConstants.After1970_UTC);
        private readonly DateOnly Before1970_UTC = DateOnly.FromDateTime(TestConstants.Before1970_UTC);
        private readonly DateOnly After1970 = DateOnly.FromDateTime(TestConstants.After1970);
        private readonly DateOnly Before1970 = DateOnly.FromDateTime(TestConstants.Before1970);
        private readonly DateOnly OutOfBounds = DateOnly.FromDateTime(TestConstants.OutOfBounds);
        private readonly TimeOnly RandomTime = new(16, 23, 12);
        private readonly int RandomTimeOffset = 58992;

        [TestMethod]
        public void ToEpoch_UTC()
        {
            After1970_UTC.ToEpochTime().Epoch.Should().Be(TestConstants.After1970_UTC_Timestamp);
            Before1970_UTC.ToEpochTime().Epoch.Should().Be(TestConstants.Before1970_UTC_Timestamp);
        }

        [TestMethod]
        public void ToEpoch()
        {
            After1970.ToEpochTime().Epoch.Should().Be(TestConstants.After1970_UTC_Timestamp);
            Before1970.ToEpochTime().Epoch.Should().Be(TestConstants.Before1970_UTC_Timestamp);
        }

        [TestMethod]
        public void ToEpoch_OutOfBounds()
        {
            var act = () => OutOfBounds.ToEpochTime().Epoch;

            act.Should().Throw<EpochTimeValueException>();
        }

        [TestMethod]
        public void ToEpoch_WithTime_UTC()
        {
            After1970_UTC.ToEpochTime(RandomTime).Epoch.Should().Be(TestConstants.After1970_UTC_Timestamp + RandomTimeOffset);
            Before1970_UTC.ToEpochTime(RandomTime).Epoch.Should().Be(TestConstants.Before1970_UTC_Timestamp + RandomTimeOffset);
        }

        [TestMethod]
        public void ToEpoch_WithTime()
        {
            After1970.ToEpochTime(RandomTime).Epoch.Should().Be(TestConstants.After1970_UTC_Timestamp + RandomTimeOffset);
            Before1970.ToEpochTime(RandomTime).Epoch.Should().Be(TestConstants.Before1970_UTC_Timestamp + RandomTimeOffset);
        }
    }
}
