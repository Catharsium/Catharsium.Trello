using System.Collections.Generic;
using Catharsium.Trello.Models;
using Catharsium.Trello.Plugins.WeeklyGoals.Models;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Logic {
    public interface IPlanningCreator {
        List<PlanningPeriod> GroupPerWeek(IEnumerable<Card> cards);
    }
}