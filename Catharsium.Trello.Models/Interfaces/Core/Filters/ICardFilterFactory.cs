using Catharsium.Util.Filters;
using System;

namespace Catharsium.Trello.Models.Interfaces.Core.Filters
{
    public interface ICardFilterFactory
    {
        IFilter<Card> CreateCreationDataFilter(DateTime fromDate, DateTime toDate);
        IFilter<Card> CreateDueDateFilter(DateTime fromDate, DateTime toDate);
    }
}