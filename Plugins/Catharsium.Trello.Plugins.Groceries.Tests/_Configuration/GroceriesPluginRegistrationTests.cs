using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Plugins.Groceries._Configuration;
using Catharsium.Trello.Plugins.Groceries.ActionHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Plugins.Groceries.Tests._Configuration
{
    [TestClass]
    public class GroceriesPluginRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            new GroceriesPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            serviceCollection.AddScoped<IActionHandler, ScheduleActionHandler>();
        }
    }
}