using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                //     .AddLogging(configure => configure.AddConsole())
                .AddTrelloConsole(configuration)
                .BuildServiceProvider();
            var console = serviceProvider.GetService<IConsole>();
            var boardsRepository = serviceProvider.GetService<IBoardsRepository>();

            var dateRetriever = serviceProvider.GetService<ICreationDateRetriever>();

            var boards = boardsRepository.GetAll(@"E:\Cloud\OneDrive\Data\Trello");
            foreach (var board in boards) {
                console.WriteLine($"{board.Name} containing {board.Lists.Count} lists, {board.Cards.Count} cards (Created: {dateRetriever.FindCreationDate(board.Id)})");
            }
        }
    }
}