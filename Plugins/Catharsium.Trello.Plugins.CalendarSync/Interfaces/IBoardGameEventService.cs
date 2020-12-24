using Catharsium.Trello.Plugins.CalendarSync.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.CalendarSync.Interfaces
{
    public interface IBoardGameEventService
    {
        Task<List<ActivityEvent>> GetEvents();
    }
}