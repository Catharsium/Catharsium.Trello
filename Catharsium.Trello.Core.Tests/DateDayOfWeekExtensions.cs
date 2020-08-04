using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Trello.Core.Tests
{
    [TestClass]
    public class DateDayOfWeekExtensions
    {
        [TestMethod]
        public void GetDayFromWeek_WeekStartsSunday_ReturnsSundayBeforeDate()
        {
            var date = new DateTime(2020, 8, 3);
            var actual = date.GetDayFromWeek(DayOfWeek.Sunday, DayOfWeek.Sunday);
            Assert.AreEqual(new DateTime(2020, 8, 2), actual.Date);
        }


        [TestMethod]
        public void GetDayFromWeek_WeekStartsMonday_ReturnsSaturdayAfterDate()
        {
            var date = new DateTime(2020, 8, 3);
            var actual = date.GetDayFromWeek(DayOfWeek.Sunday, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2020, 8, 9), actual.Date);
        }


        [TestMethod]
        public void GetDayFromWeek_Today_ReturnsToday()
        {
            var date = DateTime.Now;
            var actual = date.GetDayFromWeek(date.DayOfWeek, DayOfWeek.Monday);
            Assert.AreEqual(date.Date, actual.Date);
        }
    }
}