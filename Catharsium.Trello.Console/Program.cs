using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
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
                .AddTrelloConsole(configuration)
                .BuildServiceProvider();
     
            var chooseOperationActionHandler = serviceProvider.GetService<IChooseActionHandler>();
            await chooseOperationActionHandler.Run();
            //D:\Cloud\OneDrive\Code\Projects\Catharsium.Trello\Plugins\Catharsium.Trello.Plugins.WeeklyGoals\bin\Debug\netstandard2.0
        }
    }
}