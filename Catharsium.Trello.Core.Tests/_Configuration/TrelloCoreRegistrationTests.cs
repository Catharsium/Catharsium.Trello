using Catharsium.Trello.Core._Configuration;
using Catharsium.Trello.Models.Interfaces.Core;
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

            serviceCollection.ReceivedRegistration<ICreationDateRetriever, CreationDateRetriever>();
        }
    }
}