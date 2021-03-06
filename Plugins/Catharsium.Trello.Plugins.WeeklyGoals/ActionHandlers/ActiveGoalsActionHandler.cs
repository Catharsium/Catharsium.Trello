﻿using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers
{
    public class ActiveGoalsActionHandler : IActionHandler
    {
        private readonly IBoardsClient boardsClient;
        private readonly ITrelloServiceFactory trelloServiceFactory;
        private readonly IListsClient listsClient;
        private readonly ICreationDateRetriever creationDateRetriever;
        private readonly ICardFilterFactory cardFilterFactory;
        private readonly IConsole console;

        public string FriendlyName => "Weekly Goals > Active";


        public ActiveGoalsActionHandler(
            IBoardsClient boardsClient,
            ITrelloServiceFactory trelloServiceFactory,
            IListsClient listsClient,
            ICreationDateRetriever creationDateRetriever,
            ICardFilterFactory cardFilterFactory,
            IConsole console)
        {
            this.boardsClient = boardsClient;
            this.trelloServiceFactory = trelloServiceFactory;
            this.listsClient = listsClient;
            this.creationDateRetriever = creationDateRetriever;
            this.cardFilterFactory = cardFilterFactory;
            this.console = console;
        }


        public async Task Run()
        {
            var previousOpenCards = 0;
            var trelloService = this.trelloServiceFactory.Create("E:\\Cloud\\OneDrive\\Data\\Trello");
            var boards = (await trelloService.GetBoards()).ToList();
            foreach (var board in boards) {
                this.console.WriteLine($"{board} (Created: {this.creationDateRetriever.FindCreationDate(board.Id)})");
            }

            var goalsBoard = await trelloService.GetBoard("Weekly Goals");
            var lists = await this.boardsClient.GetLists(goalsBoard.Id);
            var openLists = lists.Where(l => !l.Name.Contains("Enjoying")).Select(l => l.Id).ToList();

            var cards = new List<Card>();
            foreach (var list in lists) {
                cards.AddRange(await this.listsClient.GetCards(list.Id));
            }

            var startDate = this.creationDateRetriever.FindCreationDate(goalsBoard.Id) ?? DateTime.Today.AddMonths(-1);

            var endDate = startDate.AddDays(7);
            while (endDate.AddDays(-7) < DateTime.Now) {
                var dateFilter = this.cardFilterFactory.CreateCreationDataFilter(startDate, endDate);

                var filteredCards = cards.Where(c => dateFilter.Includes(c)).ToList();
                var openCards = filteredCards.Where(c => openLists.Contains(c.IdList)).ToList();

                var weekFilter = this.cardFilterFactory.CreateCreationDataFilter(endDate.AddDays(-7), endDate);
                var otherCards = filteredCards.Where(c => weekFilter.Includes(c) && !openLists.Contains(c.IdList));
                var percentage = filteredCards.Any() ? Math.Round((decimal)openCards.Count / filteredCards.Count * 100, 2) : 0;
                var delta = openCards.Count - previousOpenCards;
                var deltaString = delta > 0 ? "+ " + delta : delta.ToString();
                this.console.WriteLine($"Week {endDate.AddDays(-7): d MMM yyyy} to {endDate:d MMM yyyy}");
                this.console.WriteLine(
                    $"{openCards.Count} open from {filteredCards.Count} total ({percentage} %), completed {otherCards.Count()} ({deltaString})");
                endDate = endDate.AddDays(7);
                previousOpenCards = openCards.Count;
            }
        }
    }
}