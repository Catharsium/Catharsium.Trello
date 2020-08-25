using Catharsium.Trello.Core._Configuration;
using Catharsium.Trello.Core.Filters;
using Catharsium.Trello.Core.Util;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Core.Tests._Configuration
{
    [TestClass]
    public class TrelloCoreRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddTrelloCore(configuration);

            serviceCollection.ReceivedRegistration<ICardFilterFactory, CardFilterFactory>();

            serviceCollection.ReceivedRegistration<ICreationDateRetriever, CreationDateRetriever>();
        }
    }
}