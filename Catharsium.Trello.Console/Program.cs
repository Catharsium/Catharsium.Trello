using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;
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
            var jsonFileReader = serviceProvider.GetService<IJsonFileReader>();

            var board = jsonFileReader.ReadFrom<Board>(@"D:\Cloud\OneDrive\Data\Trello\Weekly Goals.json");
            console.WriteLine(board.Name);
        }
    }
}