using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.Groceries.ActionHandlers
{
    public class ScheduleActionHandler : IActionHandler
    {
        private readonly ICardsClient cardsClient;
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly IConsole console;

        public string FriendlyName => "Schedule Groceries";


        public ScheduleActionHandler(ICardsClient cardsClient, ITrelloServiceFactory trelloServiceFactory, IConsole console)
        {
            this.cardsClient = cardsClient;
            this.trelloServiceFactory = trelloServiceFactory;
            this.console = console;
        }


        public async Task Run()
        {
            var startDate = this.console.AskForDate("Enter the start date (yyyy MM dd):") ?? DateTime.Today;
            var endDate = this.console.AskForDate("Enter the end date (yyyy MM dd):") ?? startDate.AddDays(7);

            var service = this.trelloServiceFactory.Create("D:\\Cloud\\OneDrive\\Data\\Trello");
            var list = await service.GetList("Boodschappen", "Levensmiddelen");

            while (startDate <= endDate) {
                var cardName = $"{startDate:d MMM yyyy} ({startDate.ToString("dddd", new CultureInfo("nl-NL"))})";
                var card = await this.cardsClient.CreateNew(cardName, list.IdBoard, list.Id, labels: new[] {"orange"});
                startDate = startDate.AddDays(1);
            }
        }
    }
}