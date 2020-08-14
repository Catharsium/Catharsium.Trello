using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Console.Interfaces;
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

        public string FriendlyName => "Groceries > Schedule";


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
            var list = await service.GetList("Groceries", "Levensmiddelen");
            var label = await service.GetLabel("Groceries", "orange");

            while (startDate <= endDate) {
                var cardName = $"{startDate:d MMM yyyy} ({startDate.ToString("dddd", new CultureInfo("nl-NL"))})";
                var card = await service.GetCard("Groceries", cardName);
                if (card == null) {
                    card = await this.cardsClient.CreateNew(cardName, list.IdBoard, list.Id, labels: new[] {label.Id});
                    this.console.WriteLine($"Created card '{card}'");
                }
                else { this.console.WriteLine($"Card '{cardName}' already exists"); }

                startDate = startDate.AddDays(1);
            }
        }
    }
}