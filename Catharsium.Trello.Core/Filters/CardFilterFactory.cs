using Catharsium.Trello.Models.Interfaces.Core;
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


        public ICardFilter CreateDataFilter(DateTime fromDate, DateTime toDate)
        {
            var result = this.serviceProvider.GetService<Func<DateTime, DateTime, ICardFilter>>();
            return result(fromDate, toDate);
        }
    }
}