using System;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Interfaces
{
    public interface IDatePatternResolver
    {
        string ResolveForDate(string pattern, DateTime date);
    }
}