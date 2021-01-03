using Catharsium.Trello.Plugins.WeeklyGoals._Configuration;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Trello.Plugins.WeeklyGoals.Interfaces;
using Catharsium.Trello.Plugins.WeeklyGoals.Logic;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests._Configuration
{
    [TestClass]
    public class WeeklyGoalsPluginRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            new WeeklyGoalsPluginRegistration().RegisterDependencies(serviceCollection, configuration);
            serviceCollection.AddScoped<IActionHandler, ActiveGoalsActionHandler>();
            serviceCollection.AddScoped<IActionHandler, DateFillerActionHandler>();
            serviceCollection.AddScoped<IActionHandler, PlanningActionHandler>();

            serviceCollection.AddScoped<IPlanningCreator, PlanningCreator>();
            serviceCollection.AddScoped<IDatePatternResolver, DatePatternResolver>();
        }
    }
}