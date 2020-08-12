using System;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.Filters;

namespace Catharsium.Trello.Plugins.CalendarSync.Filters
{
    public class BoardGameEventFilter : IFilter<Event>
    {
        public bool Includes(Event item)
        {
            throw new NotImplementedException();
        }
    }
}