using Catharsium.Util.Filters;
using System;

namespace Catharsium.Trello.Models.Interfaces.Core
{
    public interface ICardFilterFactory
    {
        IFilter<Card> CreateDataFilter(DateTime fromDate, DateTime toDate);
    }
}