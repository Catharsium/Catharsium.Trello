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
using System.Web;

namespace Catharsium.Trello.Api.Client.Tests.Clients
{
    [TestClass]
    public class CardsClientTests : TestFixture<CardsClient>
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
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Post<ApiCard>("cards", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("name") &&
                    p["name"] == (object)HttpUtility.UrlEncode(name) &&
                    p.ContainsKey("idBoard") &&
                    p["idBoard"] == (object)BoardId &&
                    p.ContainsKey("idList") &&
                    p["idList"] == (object)ListId &&
                    !p.ContainsKey("pos") &&
                    !p.ContainsKey("idLabels")))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId, ListId);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public async Task CreateNew_ValidOptionalFields_PostsData()
        {
            var name = "My name";
            var sourceListId = "My source list id";
            var position = "My position";
            var labels = new[] {"My label"};
            var expected = new Card();
            var apiCard = new ApiCard();
            this.GetDependency<ITrelloRestClient>().Post<ApiCard>("cards", Arg.Is<Dictionary<string, object>>(p =>
                    p.ContainsKey("pos") &&
                    p["pos"] == (object)position &&
                    p.ContainsKey("idLabels") &&
                    p["idLabels"] == (object)string.Join(",", labels)))
                .Returns(apiCard);
            this.GetDependency<IMapper>().Map<Card>(apiCard).Returns(expected);

            var actual = await this.Target.CreateNew(name, BoardId, sourceListId, position, labels);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}