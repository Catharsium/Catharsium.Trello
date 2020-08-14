using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Console.ActionHandlers.SubActions;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
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

            serviceCollection.ReceivedRegistration<IChooseActionHandler, ChooseActionHandler>();
            serviceCollection.ReceivedRegistration<IActionHandler, BrowseActionHandler>();
            serviceCollection.ReceivedRegistration<IActionHandler, CreateActionHandler>();
            serviceCollection.ReceivedRegistration<IActionHandler, ImportActionHandler>();
            serviceCollection.ReceivedRegistration<IChooseBoardActionHandler, ChooseBoardActionHandler>();
            serviceCollection.ReceivedRegistration<IChooseCardActionHandler, ChooseCardActionHandler>();
            serviceCollection.ReceivedRegistration<IChooseListActionHandler, ChooseListActionHandler>();

            serviceCollection.ReceivedRegistration<ITrelloRestClient>();
            serviceCollection.ReceivedRegistration<IFileFactory>();
            serviceCollection.ReceivedRegistration<ITrelloRepositoryFactory>();
            serviceCollection.ReceivedRegistration<ITypesRetriever>();
        }
    }
}