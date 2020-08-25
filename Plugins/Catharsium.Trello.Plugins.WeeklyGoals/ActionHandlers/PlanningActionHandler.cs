using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models.Enums;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Trello.Plugins.WeeklyGoals.Logic;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class PlanningActionHandler : IActionHandler
    {
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IPlanningCreator planningCreator;
        private readonly ICardsClient cardsClient;
        private readonly IConsole console;


        public PlanningActionHandler(
            ITrelloServiceFactory trelloServiceFactory,
            ICardFilterFactory cardFilterFactory,
            IPlanningCreator planningCreator,
            ICardsClient cardsClient,
            IConsole console)
        {
            this.trelloServiceFactory = trelloServiceFactory;
            this.cardFilterFactory = cardFilterFactory;
            this.planningCreator = planningCreator;
            this.cardsClient = cardsClient;
            this.console = console;
        }


        public string FriendlyName => "Weekly Goals > Planning";


        public async Task Run()
        {
            var repository = this.trelloServiceFactory.Create("D:\\Cloud\\OneDrive\\Data\\Trello");
            var board = await repository.GetBoard("Weekly Goals");
            var doingList = await repository.GetList("Weekly Goals", "Doing");
            var stagingList = await repository.GetList("Weekly Goals", "Staging");
            var planningList = await repository.GetList("Weekly Goals", "Planning");
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
                foreach (var periodCard in planning[selectedPeriod.Value - 1].Cards) {
                    this.console.WriteLine($"[{i++}] {periodCard.Name}");
                }

                var selectedCardIndex = this.console.AskForInt("Select the card");
                var card = selectedCardIndex.HasValue ? planning[selectedPeriod.Value - 1].Cards[selectedCardIndex.Value - 1] : null;
                if (card.Due != null) {
                    var postponedWeeks = this.console.AskForInt("How many weeks to move") ?? 0;
                    card.Due = card.Due?.AddDays(7 * postponedWeeks);
                    var dueDays = (card.Due - DateTime.Today).Value.TotalDays;
                    if (dueDays < 7) {
                        card.IdList = doingList.Id;
                    }

                    if (dueDays >= 7 && dueDays < 14) {
                        card.IdList = stagingList.Id;
                    }

                    if (dueDays >= 14) {
                        card.IdList = planningList.Id;
                    }

                    await this.cardsClient.Update(card.Id, card.IdBoard, card.IdList, due: card.Due);
                }
            }
        }
    }
}