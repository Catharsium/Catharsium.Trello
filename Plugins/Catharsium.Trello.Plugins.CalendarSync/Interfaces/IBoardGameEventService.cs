using Catharsium.Trello.Plugins.CalendarSync.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Plugins.CalendarSync.Interfaces
{
    public interface IBoardGameEventService
    {
        List<ActivityEvent> GetEvents();
    }
}