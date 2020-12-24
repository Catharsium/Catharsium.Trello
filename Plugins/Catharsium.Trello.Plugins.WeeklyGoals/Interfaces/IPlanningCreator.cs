using Catharsium.Trello.Models;
using Catharsium.Trello.Plugins.WeeklyGoals.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Interfaces
{
    public interface IPlanningCreator
    {
        List<PlanningPeriod> GroupPerWeek(IEnumerable<Card> cards);
    }
}