using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace Catharsium.Trello.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddTrelloConsole(configuration)
                .BuildServiceProvider();
            var console = serviceProvider.GetService<IConsole>();
            var boardsRepository = serviceProvider.GetService<IBoardsRepository>();
            var cardFilterFactory = serviceProvider.GetService<ICardFilterFactory>();

            var dateRetriever = serviceProvider.GetService<ICreationDateRetriever>();

            var boards = boardsRepository.GetAll(@"D:\Cloud\OneDrive\Data\Trello").ToList();
            foreach (var board in boards) {
                console.WriteLine($"{board} (Created: {dateRetriever.FindCreationDate(board.Id)})");
            }

            var goalsBoard = boards.FirstOrDefault(b => b.Name == "Weekly Goals");
            var openLists = goalsBoard.Lists.Where(l => !l.Name.Contains("Enjoying")).Select(l => l.Id);

            var startDate = dateRetriever.FindCreationDate(goalsBoard.Id);
            var endDate = startDate.Value.AddDays(7);
            while (endDate.AddDays(-7) < DateTime.Now) {
                var dateFilter = cardFilterFactory.CreateDataFilter(startDate.Value, endDate);
                var filteredCards = goalsBoard.Cards.Where(c => dateFilter.Includes(c)).ToList();
                var openCards = filteredCards.Where(c => openLists.Contains(c.IdList));

                var weekFilter = cardFilterFactory.CreateDataFilter(endDate.AddDays(-7), endDate);
                var otherCards = filteredCards.Where(c => weekFilter.Includes(c) && !openLists.Contains(c.IdList));
                console.WriteLine($"Week {endDate.AddDays(-7): d MMM yyyy} to {endDate:d MMM yyyy}");
                console.WriteLine($"{openCards.Count()} open from {filteredCards.Count} total, completed {otherCards.Count()}");
                endDate = endDate.AddDays(7);
            }
        }
    }
}