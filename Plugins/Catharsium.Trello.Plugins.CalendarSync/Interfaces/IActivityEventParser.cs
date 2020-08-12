using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Trello.Plugins.CalendarSync.Models;

namespace Catharsium.Trello.Plugins.CalendarSync.Interfaces
{
    public interface IActivityEventParser
    {
        bool CanParse(Event @event);
        ActivityEvent Parse(Event @event);
    }
}