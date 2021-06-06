using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class ChecklistGeneratorActionHandler : IActionHandler
    {
        private readonly IBoardsService boardsService;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IConsole console;

        public string FriendlyName => "Generate checklist";


        public ChecklistGeneratorActionHandler(
            IBoardsService boardsService,
            ICardFilterFactory cardFilterFactory,
            IConsole console)
        {
            this.boardsService = boardsService;
            this.cardFilterFactory = cardFilterFactory;
            this.console = console;
        }


        public async Task Run()
        {
            var plantsBoard = await this.boardsService.GetBoard("Plants");
            var ripList = plantsBoard.Lists.FirstOrDefault(l => l.Name == "RIP");
            var filter = this.cardFilterFactory.CreateListFilter();
            var cards = plantsBoard.Cards.Exclude(filter);
            foreach (var card in cards) {
                this.console.WriteLine(card.Name);
            }
        }
    }
}