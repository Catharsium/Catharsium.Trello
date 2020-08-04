using System;

namespace Catharsium.Trello.Core
{
    public static class DateDayOfWeekExtensions
    {
        public static DateTime GetDayFromWeek(this DateTime date, DayOfWeek day, DayOfWeek firstDay = DayOfWeek.Sunday)
        {
            var currentDate = date.Date;
            while (currentDate.DayOfWeek != day) {
                if (currentDate.DayOfWeek == firstDay) {
                    currentDate = currentDate.AddDays(7);
                }

                currentDate = currentDate.AddDays(-1);
            }

            return currentDate;
        }
    }
}