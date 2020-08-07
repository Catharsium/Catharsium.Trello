using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
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
    }
}