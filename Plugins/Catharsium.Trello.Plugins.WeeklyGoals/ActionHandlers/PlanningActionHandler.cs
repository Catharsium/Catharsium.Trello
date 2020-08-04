using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using Catharsium.Trello.Core;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class PlanningActionHandler : IActionHandler
    {
        private readonly ITrelloRepositoryFactory boardsRepositoryFactory;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IConsole console;


        public PlanningActionHandler(ITrelloRepositoryFactory boardsRepositoryFactory, ICardFilterFactory cardFilterFactory, IConsole console)
        {
            this.boardsRepositoryFactory = boardsRepositoryFactory;
            this.cardFilterFactory = cardFilterFactory;
            this.console = console;
        }


        public string FriendlyName => "Planning";


        public async Task Run()
        {
            var repository = this.boardsRepositoryFactory.Create("D:\\Cloud\\OneDrive\\Data\\Trello");
            var board = await repository.GetBoard("Weekly Goals");
            if (board == null) {
                return;
            }

            var maximumListPosition = board.Lists.First(l => l.Name == "Doing").Pos;
            var lists = board.Lists.Where(l => l.Pos <= maximumListPosition).Select(l => l.Id);
            var cards = board.Cards.Where(c => lists.Contains(c.IdList)).Where(c => c.Due.HasValue).ToList();

            var startDate = DateTime.Now.GetDayFromWeek(DayOfWeek.Sunday).Date.AddHours(-7);
            var endDate = startDate.AddDays(7);
            while (cards.Any(c => c.Due > endDate)) {
                var dateFilter = this.cardFilterFactory.CreateDataFilter(startDate, endDate);
                var filteredCards = cards.Include(dateFilter).ToArray();
                this.console.Write($"Due {endDate:yyyy-MM-dd} ");
                this.console.ForegroundColor = filteredCards.Length > 6 ? ConsoleColor.Red : ConsoleColor.Green;
                this.console.Write(filteredCards.Length.ToString());
                this.console.ResetColor();
                this.console.WriteLine(" goals");
                foreach (var card in filteredCards) {
                    this.console.WriteLine($"\t{card.Name}");
                }
                startDate = endDate;
                endDate = endDate.AddDays(7);
            }
        }
    }
}