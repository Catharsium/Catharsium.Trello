using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using Catharsium.Trello.Api.Client._Configuration;

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

        #region GetList

        [TestMethod]
        public async Task GetList_ValidRequest_ReturnsRestClientResult()
        {
            var expected = new ApiBoard[0];
            this.GetDependency<ITrelloRestClient>().Get<ApiBoard[]>("boards").Returns(expected);

            var actual = await this.Target.GetList();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}