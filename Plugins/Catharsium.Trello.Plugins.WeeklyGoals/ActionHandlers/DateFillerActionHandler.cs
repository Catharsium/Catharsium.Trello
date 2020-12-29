using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Core.Util;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Trello.Plugins.WeeklyGoals._Configuration;
using Catharsium.Trello.Plugins.WeeklyGoals.Interfaces;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class DateFillerActionHandler : IActionHandler
    {
        private readonly IBoardsService boardsService;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IDatePatternResolver datePatternResolver;
        private readonly ICardsClient cardsClient;
        private readonly IConsole console;
        private readonly WeeklyGoalsPluginConfiguration configuation;

        public string FriendlyName => "Fill Dates";


        public DateFillerActionHandler(
            IBoardsService boardsService,
            ICardFilterFactory cardFilterFactory,
            IDatePatternResolver datePatternResolver,
            ICardsClient cardsClient,
            IConsole console,
            WeeklyGoalsPluginConfiguration configuation)
        {
            this.boardsService = boardsService;
            this.cardFilterFactory = cardFilterFactory;
            this.datePatternResolver = datePatternResolver;
            this.cardsClient = cardsClient;
            this.console = console;
            this.configuation = configuation;
        }


        public async Task Run()
        {
            var board = await this.boardsService.GetBoard(this.configuation.BoardId);
            var list = board.Lists.FirstOrDefault(l => l.Name == "Doing");
            var filter = this.cardFilterFactory.CreateListFilter(list.Id);
            await this.RenameCards(board.Cards.Include(filter), 0);

            list = board.Lists.FirstOrDefault(l => l.Name == "Staging");
            filter = this.cardFilterFactory.CreateListFilter(list.Id);
            await this.RenameCards(board.Cards.Include(filter), 1);

            list = board.Lists.FirstOrDefault(l => l.Name == "Planning");
            filter = this.cardFilterFactory.CreateListFilter(list.Id);
            await this.RenameCards(board.Cards.Include(filter), 2);
        }


        private async Task RenameCards(IEnumerable<Card> cards, int weeksFromNow)
        {
            foreach (var card in cards)
            {
                var match = Regex.Match(card.Name, "(.+) \\(#(.+)\\)");
                if (match.Success)
                {
                    var pivotDate = DateTime.Now.AddDays(7 * weeksFromNow);
                    var dueDate = pivotDate.GetDayFromWeek(DayOfWeek.Sunday).AddDays(7).Date.AddHours(-7);
                    var dateForName = this.datePatternResolver.ResolveForDate(match.Groups[2].Value, pivotDate);
                    var newName = $"{match.Groups[1]} ({dateForName})";
                    this.console.Write($"Renaming '{card.Name}' to '");
                    this.console.ForegroundColor = ConsoleColor.Red;
                    this.console.Write(newName);
                    this.console.ResetColor();
                    this.console.Write($"' (Due: {dueDate:yyyy-MM-dd})");
                    await this.cardsClient.Update(card.Id, card.IdBoard, card.IdList, name: newName, due: dueDate);
                }
            }
        }
    }
}