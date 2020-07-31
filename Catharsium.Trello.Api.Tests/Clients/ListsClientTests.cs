using AutoMapper;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Tests.Clients
{
    [TestClass]
    public class ListsClientTests : TestFixture<ListsClient>
    {
        #region Fixture

        private static string BoardId => "My board id";
        private static string ListId => "My list id";

        #endregion

        #region CreateNew

        [TestMethod]
        public async Task CreateNew_ValidRequiredFields_PostsData()
        {
            var name = "My name";
            var expected = "My result";
            this.GetDependency<ITrelloRestClient>().Post<string>("lists", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("name") &&
                    p["name"] == (object)name &&
                    p.ContainsKey("idBoard") &&
                    p["idBoard"] == (object)BoardId &&
                    !p.ContainsKey("idListSource") &&
                    !p.ContainsKey("pos")))
                .Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public async Task CreateNew_ValidOptionalFields_PostsData()
        {
            var name = "My name";
            var sourceListId = "My source list id";
            var position = "My position";
            var expected = "My result";
            this.GetDependency<ITrelloRestClient>().Post<string>("lists", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("idListSource") &&
                    p["idListSource"] == (object)sourceListId &&
                    p.ContainsKey("pos") &&
                    p["pos"] == (object)position))
                .Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId, sourceListId, position);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetLists

        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsRestClientResult()
        {
            this.GetDependency<ITrelloRestClient>().Get<string>($"lists/{ListId}/board").Returns(BoardId);
            var actual = await this.Target.GetBoard(ListId);
            Assert.AreEqual(BoardId, actual);
        }

        #endregion

        #region GetLists


        [TestMethod]
        public async Task GetCards_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiCard[0];
            var expected = new Card[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiCard[]>($"lists/{ListId}/cards").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Card[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetCards(ListId);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}