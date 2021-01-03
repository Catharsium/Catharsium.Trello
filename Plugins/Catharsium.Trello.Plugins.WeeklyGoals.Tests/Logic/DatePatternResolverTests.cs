using Catharsium.Trello.Plugins.WeeklyGoals.Logic;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests.Logic
{
    [TestClass]
    public class DatePatternResolverTests : TestFixture<DatePatternResolver>
    {
        [TestMethod]
        public void ResolveForDate_WeekPatternAndJanuary1_ReturnsFormattedWeekNumber()
        {
            var date = new DateTime(2020, 1, 1);
            var actual = this.Target.ResolveForDate("yyyy-W", date);
            Assert.AreEqual("2020-01", actual);
        }


        [TestMethod]
        public void ResolveForDate_WeekPatternAndDecember31_ReturnsFormattedWeekNumber()
        {
            var date = new DateTime(2020, 12, 31);
            var actual = this.Target.ResolveForDate("yyyy-W", date);
            Assert.AreEqual("2020-53", actual);
        }


        [TestMethod]
        public void ResolveForDate_WeekPattern_ReturnsFormattedWeekNumber()
        {
            var date = new DateTime(2020, 10, 11);
            var actual = this.Target.ResolveForDate("yyyy-W", date);
            Assert.AreEqual("2020-41", actual);
        }


        [TestMethod]
        public void ResolveForDate_WeekPattern_ReturnsFormattedMonthNumber()
        {
            var date = new DateTime(2020, 10, 11);
            var actual = this.Target.ResolveForDate("yyyy-M", date);
            Assert.AreEqual("2020-10", actual);
        }
    }
}