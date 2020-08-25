using Catharsium.Trello.Models;
using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Models
{
    public class PlanningPeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Card> Cards { get; set; }
    }
}