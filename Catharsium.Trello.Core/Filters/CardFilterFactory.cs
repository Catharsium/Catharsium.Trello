using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
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


        public IFilter<Card> CreateDataFilter(DateTime fromDate, DateTime toDate)
        {
            var result = this.serviceProvider.GetService<Func<DateTime, DateTime, IFilter<Card>>>();
            return result(fromDate, toDate);
        }
    }
}