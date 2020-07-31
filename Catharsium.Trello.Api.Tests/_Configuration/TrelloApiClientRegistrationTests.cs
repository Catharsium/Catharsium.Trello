using AutoMapper;
using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Services;
using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Api.Client.Tests._Configuration
{
    [TestClass]
    public class TrelloApiClientRegistrationTests
    {
        [TestMethod]
        public void AddTrelloApiClient_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddTrelloApiClient(configuration);
            serviceCollection.ReceivedRegistration<IBoardsClient, BoardsClient>();
            serviceCollection.ReceivedRegistration<IListsClient, ListsClient>();

            serviceCollection.ReceivedRegistration<IBoardsService, BoardsService>();

            serviceCollection.ReceivedRegistration<IMapper>();
        }
    }
}