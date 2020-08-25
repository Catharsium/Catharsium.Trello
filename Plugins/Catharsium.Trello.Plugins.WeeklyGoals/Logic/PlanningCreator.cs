using Catharsium.Trello.Core;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Plugins.WeeklyGoals.Models;
using Catharsium.Util.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Trello.Core.Util;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Logic
{
    public class PlanningCreator : IPlanningCreator
    {
        private readonly ICardFilterFactory cardFilterFactory;


        public PlanningCreator(ICardFilterFactory cardFilterFactory)
        {
            this.cardFilterFactory = cardFilterFactory;
        }


        public List<PlanningPeriod> GroupPerWeek(IEnumerable<Card> cards)
        {
            var startDate = DateTime.Now.GetDayFromWeek(DayOfWeek.Sunday).Date.AddHours(-7);
            var endDate = startDate.AddDays(7);
            var dateFilter = this.cardFilterFactory.CreateDueDateFilter(DateTime.MinValue, endDate);

            var result = new List<PlanningPeriod>();
            var cardsArray = cards as Card[] ?? cards.ToArray();
            while (cardsArray.Any(c => c.Due > startDate)) {
                result.Add(new PlanningPeriod {
                    Cards = cardsArray.Include(dateFilter).ToList(),
                    StartDate = startDate,
                    EndDate = endDate
                });

                startDate = endDate;
                endDate = endDate.AddDays(7);
                dateFilter = this.cardFilterFactory.CreateDueDateFilter(startDate, endDate);
            }

            return result;
        }
    }
}