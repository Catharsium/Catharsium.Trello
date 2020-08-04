using Catharsium.Util.Filters;
using System;

namespace Catharsium.Trello.Models.Interfaces.Core.Filters
{
    public interface ICardFilterFactory
    {
        IFilter<Card> CreateCreationDataFilter(DateTime fromDate, DateTime toDate);
        IFilter<Card> CreateDataFilter(DateTime fromDate, DateTime toDate);
    }
}