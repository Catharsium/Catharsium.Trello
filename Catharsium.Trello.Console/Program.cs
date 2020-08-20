using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.CalendarSync._Configuration;
using Catharsium.Trello.Plugins.Groceries._Configuration;
using Catharsium.Trello.Plugins.WeeklyGoals._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            var serviceCollection = new ServiceCollection()
                .AddTrelloConsole(configuration);
            new GroceriesPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            new WeeklyGoalsPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            //new CalendarSyncPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var fileFactory = serviceProvider.GetService<IFileFactory>();
            var pluginDirectory = fileFactory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Plugins");
            var assemblies =
                (from file in pluginDirectory.GetFiles("*.dll")
                    let loadContext = new PluginLoadContext(file.FullName)
                    select loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(file.FullName))))
                .ToList();

            var pluginRegistrations = assemblies.SelectMany(CreateCommands);
            foreach (var pluginRegistration in pluginRegistrations) {
                pluginRegistration.RegisterDependencies(serviceCollection, configuration);
            }

            serviceProvider = serviceCollection.BuildServiceProvider();

            var chooseOperationActionHandler = serviceProvider.GetService<IChooseActionHandler>();
            await chooseOperationActionHandler.Run();
        }


        private static IEnumerable<IPluginRegistration> CreateCommands(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes()) {
                if (!typeof(IPluginRegistration).IsAssignableFrom(type)) {
                    continue;
                }

                if (!(Activator.CreateInstance(type) is IPluginRegistration result)) {
                    continue;
                }

                yield return result;
            }
        }
    }
}