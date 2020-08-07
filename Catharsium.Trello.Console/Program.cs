using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Util.Interfaces;

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

            var serviceCollection = new ServiceCollection()
                .AddTrelloConsole(configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var typesLoader = serviceProvider.GetService<ITypesLoader>();
            var types = typesLoader.Load<IPluginRegistration>($"{Directory.GetCurrentDirectory()}/Plugins");
            foreach (var type in types) {
                if (Activator.CreateInstance(type) is IPluginRegistration instance) {
                    instance.RegisterDependencies(serviceCollection, configuration);
                }
            }

            serviceProvider = serviceCollection.BuildServiceProvider();

            var chooseOperationActionHandler = serviceProvider.GetService<IChooseActionHandler>();
            await chooseOperationActionHandler.Run();
        }
    }
}