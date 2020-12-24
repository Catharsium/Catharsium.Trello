using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Enums;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Core.Filters.Cards;
using Catharsium.Util.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Catharsium.Trello.Core.Filters
{
    public class CardFilterFactory : ICardFilterFactory
    {
        private readonly IServiceProvider serviceProvider;


        public CardFilterFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public IFilter<Card> CreateCreationDataFilter(DateTime fromDate, DateTime toDate)
        {
            var result = this.serviceProvider.GetService<Func<DateTime, DateTime, ICreationDateFilter>>();
            return result(fromDate, toDate);
        }


        public IFilter<Card> CreateDueDateFilter(DateTime fromDate, DateTime toDate)
        {
            var result = this.serviceProvider.GetService<Func<DateTime, DateTime, IDueDateFilter>>();
            return result(fromDate, toDate);
        }


        public IFilter<Card> CreateCardStateFilter(CardState cardState)
        {
            var result = this.serviceProvider.GetService<Func<CardState, ICardStateFilter>>();
            return result(cardState);
        }

        public IFilter<Card> CreateListFilter(params string[] listIds)
        {
            var result = this.serviceProvider.GetService<Func<string[], IListFilter>>();
            return result(listIds);
        }
    }
}