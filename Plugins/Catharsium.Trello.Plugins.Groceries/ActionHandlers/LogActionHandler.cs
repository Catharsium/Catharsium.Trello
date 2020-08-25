using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Console.Interfaces;

namespace Catharsium.Trello.Plugins.Groceries.ActionHandlers
{
    public class LogActionHandler : IActionHandler
    {
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly ICardsClient cardsClient;
        private readonly IConsole console;

        public string FriendlyName => "Groceries > Log";


        public LogActionHandler(
            ITrelloServiceFactory trelloServiceFactory,
            ICardsClient cardsClient, 
            IConsole console)
        {
            this.trelloServiceFactory = trelloServiceFactory;
            this.cardsClient = cardsClient;
            this.console = console;
        }


        public async Task Run()
        {
            var service = this.trelloServiceFactory.Create("D:\\Cloud\\OneDrive\\Data\\Trello");
            var board = await service.GetBoard("Groceries");
            var list = await service.GetList("Groceries", "Levensmiddelen");
            if (board == null || list == null)
            {
                return;
            }

            var cardName = this.console.AskForText("Enter the grocery name");
            var dueDate = this.console.AskForDate("Enter the due date (default: today)");

            await this.cardsClient.CreateNew(cardName, board.Id, list.Id, "bottom", due: DateTime.Today, isDone: true);

            //var i = 1;
            //foreach (var card in board.Cards) {
            //    if (card.IdList == list.Id) {
            //        this.console.WriteLine($"[{i++}]\t{card.Name}");
            //    }
            //}
        }
    }
}