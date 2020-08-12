using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Trello.Plugins.CalendarSync.Interfaces;
using Catharsium.Trello.Plugins.CalendarSync.Models;
using System.Text.RegularExpressions;

namespace Catharsium.Trello.Plugins.CalendarSync.Parsers
{
    public class BoardGameActivityEventParser : IActivityEventParser
    {
        public bool CanParse(Event @event)
        {
            return Regex.IsMatch(@event.Description, "^Board game \\(.+\\)$");
        }


        public ActivityEvent Parse(Event @event)
        {
            var match = Regex.Match(@event.Description, "^.+ \\((.+)\\)$");
            return new ActivityEvent {
                ActivityGroupName = "Board game",
                ActivityName = match.Success ? match.Groups[1].Value : ""
            };
        }
    }
}