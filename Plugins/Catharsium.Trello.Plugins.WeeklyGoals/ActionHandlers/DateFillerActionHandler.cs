using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Core.Util;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Trello.Plugins.WeeklyGoals.Interfaces;
using Catharsium.Util.Filters;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class DateFillerActionHandler : IActionHandler
    {
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IDatePatternResolver datePatternResolver;
        private readonly ICardsClient cardsClient;
        private readonly IConsole console;

        public string FriendlyName => "Fill Dates";


        public DateFillerActionHandler(
            ITrelloServiceFactory trelloServiceFactory,
            ICardFilterFactory cardFilterFactory,
            IDatePatternResolver datePatternResolver,
            ICardsClient cardsClient,
            IConsole console)
        {
            this.trelloServiceFactory = trelloServiceFactory;
            this.cardFilterFactory = cardFilterFactory;
            this.datePatternResolver = datePatternResolver;
            this.cardsClient = cardsClient;
            this.console = console;
        }

        public async Task Run()
        {
            var repository = this.trelloServiceFactory.Create("E:\\Cloud\\OneDrive\\Data\\Trello");
            var board = await repository.GetBoard("Weekly Goals");
            var list = await repository.GetList("Weekly Goals", "Doing");
            var filter = this.cardFilterFactory.CreateListFilter(list.Id);
            await this.RenameCards(board.Cards.Include(filter), 0);

            list = await repository.GetList("Weekly Goals", "Staging");
            filter = this.cardFilterFactory.CreateListFilter(list.Id);
            await this.RenameCards(board.Cards.Include(filter), 1);

            list = await repository.GetList("Weekly Goals", "Planning");
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
                    var dueDate = DateTime.Now.Date
                        .GetDayFromWeek(DayOfWeek.Sunday)
                        .AddDays(7 * weeksFromNow)
                        .AddHours(-7);
                    var date = this.datePatternResolver.ResolveForDate(match.Groups[2].Value, dueDate);
                    await this.cardsClient.Update(card.Id, card.IdBoard, card.IdList, name: $"{match.Groups[1]} ({date})", due: dueDate);
                }
            }
        }
    }
}