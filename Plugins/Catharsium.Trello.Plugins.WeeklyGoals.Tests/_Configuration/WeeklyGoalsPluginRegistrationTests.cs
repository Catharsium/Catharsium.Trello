﻿using Catharsium.Trello.Plugins.WeeklyGoals._Configuration;
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

            serviceCollection.AddWeeklyGoalsPlugin(configuration);
        }
    }
}