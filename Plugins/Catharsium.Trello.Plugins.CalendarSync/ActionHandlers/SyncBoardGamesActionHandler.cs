using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Trello.Plugins.CalendarSync.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.CalendarSync.ActionHandlers
{
    public class SyncBoardGamesActionHandler : IActionHandler
    {
        private readonly IBoardGameEventService boardGameEventService;
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly ICardsClient cardsClient;

        public string FriendlyName => "CalendarSync: Sync Board games";


        public SyncBoardGamesActionHandler(IBoardGameEventService boardGameEventService, ITrelloServiceFactory trelloServiceFactory,
            ICardsClient cardsClient)
        {
            this.boardGameEventService = boardGameEventService;
            this.trelloServiceFactory = trelloServiceFactory;
            this.cardsClient = cardsClient;
        }


        public async Task Run()
        {
            var events = this.boardGameEventService.GetEvents();
            var groups = events.GroupBy(e => e.ActivityName);
            foreach (var group in groups) {
                var totalTime = new TimeSpan();
                totalTime = @group.Aggregate(totalTime, (current, @event) => current + (@event.Event.End.Value - @event.Event.Start.Value));
                var timeSpend = $"{(int)totalTime.TotalHours}:{totalTime.Minutes}";
                await this.cardsClient.CreateNew($"{group.Key} ({timeSpend} uur)", "t.w.brachthuizer@gmail.com", "");
            }
        }
    }
}