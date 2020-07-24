using Catharsium.Trello.Api;
using Catharsium.Trello.Api.Client;
using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Console.Tests._Configuration
{
    [TestClass]
    public class TrelloConsoleRegistrationTests
    {
        [TestMethod]
        public void AddCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddTrelloConsole(configuration);

            serviceCollection.ReceivedRegistration<IChooseBoardActionHandler, ChooseBoardActionHandler>();
            serviceCollection.ReceivedRegistration<IChooseCardActionHandler, ChooseCardActionHandler>();
            serviceCollection.ReceivedRegistration<IChooseListActionHandler, ChooseListActionHandler>();

            serviceCollection.ReceivedRegistration<ITrelloRestClient>();
            serviceCollection.ReceivedRegistration<IFileFactory>();
            serviceCollection.ReceivedRegistration<IBoardsRepository>();
        }
    }
}