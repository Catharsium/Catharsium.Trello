using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Trello.Plugins.CalendarSync.Interfaces;
using Catharsium.Trello.Plugins.CalendarSync.Models;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using Catharsium.Calendar.Data.Google.Interfaces;

namespace Catharsium.Trello.Plugins.CalendarSync.Parsers
{
    public class BoardGameEventService : IBoardGameEventService
    {
        private readonly ICalendarClientFactory fff;
        private readonly ICalendarService calendarService;
        private readonly IEventManagementService eventManagementService;
        private readonly IEventFilterFactory eventFilterFactory;
        private readonly IConsole console;


        public BoardGameEventService(ICalendarClientFactory fff, ICalendarService calendarService, IEventManagementService eventManagementService, IEventFilterFactory eventFilterFactory, IConsole console)
        {
            this.fff = fff;
            this.fff.UserName = "t.w.brachthuizer@gmail.com";
            this.calendarService = calendarService;
            this.eventManagementService = eventManagementService;
            this.eventFilterFactory = eventFilterFactory;
            this.console = console;
        }


        public List<ActivityEvent> GetEvents()
        {
            var result = new List<Event>();
            var calendars = this.calendarService.GetList();
            foreach (var calendar in calendars) {
                this.console.WriteLine($"{calendar.Description} - {calendar.Id}");
            }
            var events = this.eventManagementService.GetList("t.w.brachthuizer@gmail.com", DateTime.MinValue, DateTime.Now);
            throw new NotImplementedException();
           // return result;
        }
    }
}