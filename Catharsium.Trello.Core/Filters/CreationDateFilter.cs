using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Core.Filters.Cards;
using System;

namespace Catharsium.Trello.Core.Filters
{
    public class CreationDateFilter : ICreationDateFilter
    {
        private readonly ICreationDateRetriever creationDateRetriever;
        private readonly DateTime fromDate;
        private readonly DateTime toDate;


        public CreationDateFilter(ICreationDateRetriever creationDateRetriever, DateTime fromDate, DateTime toDate)
        {
            this.creationDateRetriever = creationDateRetriever;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }


        public bool Includes(Card card)
        {
            var cardDate = this.creationDateRetriever.FindCreationDate(card.Id);
            return this.fromDate <= cardDate &&
                   cardDate <= this.toDate;
        }
    }
}