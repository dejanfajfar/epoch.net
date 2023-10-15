using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Epoch.net.Test
{
    [TestClass]
    public class DateOnlyExtensionsFitxture
    {

        [TestMethod]
        public void ToEpoch()
        {
            DateOnly.FromDateTime(TestConstants.After1970_UTC).ToEpochTime().Epoch.Should().Be(TestConstants.After1970_UTC_Timestamp);
            DateOnly.FromDateTime(TestConstants.Before1970_UTC).ToEpochTime().Epoch.Should().Be(TestConstants.Before1970_UTC_Timestamp);
        }
    }
}
