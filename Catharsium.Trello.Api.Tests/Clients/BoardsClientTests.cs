using AutoMapper;
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

        private static string BoardId => "My board id";

        #endregion

        #region GetAll

        [TestMethod]
        public async Task GetAll_ValidRequest_ReturnsRestClientResult()
        {
            var apiResult = new ApiBoard[0];
            var expected = new Board[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiBoard[]>("members/me/boards").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Board[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetAll();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetBoard

        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiBoard();
            var expected = new Board();
            this.GetDependency<ITrelloRestClient>().Get<ApiBoard>($"boards/{BoardId}").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Board>(apiResult).Returns(expected);

            var actual = await this.Target.GetBoard(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetLists

        [TestMethod]
        public async Task GetLists_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiList[0];
            var expected = new List[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiList[]>($"boards/{BoardId}/lists").Returns(apiResult);
            this.GetDependency<IMapper>().Map<List[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetLists(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetCards

        [TestMethod]
        public async Task GetCards_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiCard[0];
            var expected = new Card[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiCard[]>($"boards/{BoardId}/cards").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Card[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetCards(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetActions

        [TestMethod]
        public async Task GetActions_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiAction[0];
            var expected = new Action[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiAction[]>($"boards/{BoardId}/actions").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Action[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetActions(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetChecklists

        [TestMethod]
        public async Task GetChecklists_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiChecklist[0];
            var expected = new Checklist[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiChecklist[]>($"boards/{BoardId}/checklists").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Checklist[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetChecklists(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetLabels

        [TestMethod]
        public async Task GetLabels_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiLabel[0];
            var expected = new Label[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiLabel[]>($"boards/{BoardId}/labels").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Label[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetLabels(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetMemberships

        [TestMethod]
        public async Task GetMemberships_ValidId_ReturnsRestClientResult()
        {
            var apiResult = new ApiMembership[0];
            var expected = new Membership[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiMembership[]>($"boards/{BoardId}/memberships").Returns(apiResult);
            this.GetDependency<IMapper>().Map<Membership[]>(apiResult).Returns(expected);

            var actual = await this.Target.GetMemberships(BoardId);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}