using Catharsium.Calendar.Core.Entities.Models;

namespace Catharsium.Trello.Plugins.CalendarSync.Models
{
    public class ActivityEvent
    {
        public string ActivityGroupName { get; set; }
        public string ActivityName { get; set; }
        public Event Event { get; set; }
    }
}