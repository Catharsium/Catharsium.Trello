using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using System;

namespace Catharsium.Trello.Core.Filters
{
    public class DueDateFilter : IDueDateFilter
    {
        private readonly DateTime fromDate;
        private readonly DateTime toDate;


        public DueDateFilter(DateTime fromDate, DateTime toDate)
        {
            this.fromDate = fromDate;
            this.toDate = toDate;
        }


        public bool Includes(Card card)
        {
            return card.Due.HasValue &&
                   (this.fromDate <= card.Due && card.Due <= this.toDate);
        }
    }
}