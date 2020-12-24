using Catharsium.Trello.Models.Enums;
using Catharsium.Util.Filters;
using System;

namespace Catharsium.Trello.Models.Interfaces.Core.Filters
{
    public interface ICardFilterFactory
    {
        IFilter<Card> CreateCreationDataFilter(DateTime fromDate, DateTime toDate);
        IFilter<Card> CreateDueDateFilter(DateTime fromDate, DateTime toDate);
        IFilter<Card> CreateCardStateFilter(CardState cardState);
        IFilter<Card> CreateListFilter(params string[] listIds);
    }
}