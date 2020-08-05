using Catharsium.Trello.Data._Configuration;
using Catharsium.Trello.Data.Repository;
using Catharsium.Trello.Data.Services;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Data.Tests._Configuration
{
    [TestClass]
    public class TrelloDataRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddTrelloData(configuration);
            serviceCollection.ReceivedRegistration<ITrelloRepositoryFactory, TrelloRepositoryFactory>();
            serviceCollection.ReceivedRegistration<ITrelloServiceFactory, TrelloServiceFactory>();
        }
    }
}