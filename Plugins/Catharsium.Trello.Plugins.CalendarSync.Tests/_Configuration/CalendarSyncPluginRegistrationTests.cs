using Catharsium.Trello.Plugins.CalendarSync._Configuration;
using Catharsium.Trello.Plugins.CalendarSync.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Plugins.CalendarSync.Tests._Configuration
{
    [TestClass]
    public class CalendarSyncPluginRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            new CalendarSyncPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            serviceCollection.AddScoped<IActionHandler, SyncBoardGamesActionHandler>();
        }
    }
}