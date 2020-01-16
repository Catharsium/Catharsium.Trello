using System;

namespace Catharsium.Trello.Models.Interfaces.Core
{
    public interface ICardFilterFactory
    {
        ICardFilter CreateDataFilter(DateTime fromDate, DateTime toDate);
    }
}