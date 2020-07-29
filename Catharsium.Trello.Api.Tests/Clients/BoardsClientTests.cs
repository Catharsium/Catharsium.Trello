using AutoMapper;
using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Tests.Clients
{
    [TestClass]
    public class BoardsClientTests : TestFixture<BoardsClient>
    {
        #region Fixture

        public TrelloApiClientConfiguration Configuration { get; set; }
        public string BaseUrl => "My base url";


        [TestInitialize]
        public void SetupDependencies()
        {
            this.SetDependency(this.Configuration);
            this.SetDependency(this.BaseUrl);
        }

        #endregion

        #region GetAll

        [TestMethod]
        public async Task GetAll_ValidRequest_ReturnsRestClientResult()
        {
            var apiResult = new ApiBoard[0];
            var expected = new Board[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiBoard[]>("boards").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Board[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetAll();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetLists

        [TestMethod]
        public async Task GetLists_ValidId_ReturnsRestClientResult()
        {
            var boardId = "My board id";
            var apiResult = new ApiList[0];
            var expected = new List[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiList[]>($"boards/{boardId}/lists").Returns(apiResult);
            this.GetDependency<IMapper>().Map<List[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetLists(boardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}