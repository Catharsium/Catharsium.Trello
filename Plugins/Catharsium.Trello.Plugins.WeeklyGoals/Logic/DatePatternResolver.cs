using Catharsium.Trello.Plugins.WeeklyGoals.Interfaces;
using Catharsium.Util.Time.Extensions;
using System;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Logic
{
    public class DatePatternResolver : IDatePatternResolver
    {
        public string ResolveForDate(string pattern, DateTime date)
        {
            return pattern switch
            {
                "yyyy" => $"{date:yyyy}",
                "yyyy-M" => $"{date:yyyy-MM}",
                "yyyy-W" => $"{date:yyyy}-{date.GetWeekOfYear():00}",
                _ => pattern,
            };
        }
    }
}