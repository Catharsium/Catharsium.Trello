using Catharsium.Trello.Core;
using Catharsium.Trello.Models.Enums;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Plugins.WeeklyGoals.Logic;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class PlanningActionHandler : IActionHandler
    {
        private readonly ITrelloRepositoryFactory trelloRepositoryFactory;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IPlanningCreator planningCreator;
        private readonly ICardsClient cardsClient;
        private readonly IConsole console;


        public PlanningActionHandler(
            ITrelloRepositoryFactory trelloRepositoryFactory,
            ICardFilterFactory cardFilterFactory,
            IPlanningCreator planningCreator,
            ICardsClient cardsClient,
            IConsole console)
        {
            this.trelloRepositoryFactory = trelloRepositoryFactory;
            this.cardFilterFactory = cardFilterFactory;
            this.planningCreator = planningCreator;
            this.cardsClient = cardsClient;
            this.console = console;
        }


        public string FriendlyName => "Weekly Goals > Planning";


        public async Task Run()
        {
            var repository = this.trelloRepositoryFactory.Create("D:\\Cloud\\OneDrive\\Data\\Trello");
            var board = await repository.GetBoard("Weekly Goals");
            if (board == null) {
                return;
            }

            var cards = board.Cards.Include(this.cardFilterFactory.CreateCardStateFilter(CardState.Open)).ToList();
            var planning = this.planningCreator.GroupPerWeek(cards);

            var i = 1;
            foreach (var period in planning) {
                this.console.Write($"[{i++}] Due {period.EndDate:yyyy-MM-dd} ");
                this.console.ForegroundColor = period.Cards.Count > 6 ? ConsoleColor.Red : ConsoleColor.Green;
                this.console.Write(period.Cards.Count.ToString());
                this.console.ResetColor();
                this.console.WriteLine(" goals");
            }

            var selectedPeriod = this.console.AskForInt("Select the period");
            i = 1;
            if (selectedPeriod.HasValue && selectedPeriod.Value > 0 && selectedPeriod.Value <= planning.Count) {
                foreach (var card in planning[selectedPeriod.Value - 1].Cards) {
                    this.console.WriteLine($"[{i++}] {card.Name}");
                }
            }

            var selectedCard = this.console.AskForInt("Select the card");
            var postponedWeeks = this.console.AskForInt("How many weeks to move");

            //this.cardsClient.
        }
    }
}