using Catharsium.Trello.Data.Services;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Tests.Services
{
    [TestClass]
    public class TrelloServiceTests : TestFixture<TrelloService>
    {
        #region Fixture

        private static string Folder => "My folder";
        private static string BoardId => "My board id";
        private static string ListId => "My list id";

        public Board Board { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.Board = new Board {
                Id = "My board id"
            };
            this.SetDependency(Folder, "folder");
        }

        #endregion

        #region GetList

        [TestMethod]
        public async Task GetList_ValidId_ReturnsListWithId()
        {
            var repository = Substitute.For<ITrelloRepository>();
            this.Board.Lists = new List<List> {
                new List {Id = ListId}
            };
            repository.GetBoard(BoardId).Returns(this.Board);
            this.GetDependency<ITrelloRepositoryFactory>().Create(Folder).Returns(repository);

            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.AreEqual(this.Board.Lists[0], actual);
        }


        [TestMethod]
        public async Task GetList_ValidName_ReturnsListWithName()
        {
            var repository = Substitute.For<ITrelloRepository>();
            this.Board.Lists = new List<List> {
                new List {Name = ListId}
            };
            repository.GetBoard(BoardId).Returns(this.Board);
            this.GetDependency<ITrelloRepositoryFactory>().Create(Folder).Returns(repository);

            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.AreEqual(this.Board.Lists[0], actual);
        }


        [TestMethod]
        public async Task GetList_InvalidListId_ReturnsNull()
        {
            var repository = Substitute.For<ITrelloRepository>();
            this.Board.Lists = new List<List> {new List()};
            repository.GetBoard(BoardId).Returns(this.Board);
            this.GetDependency<ITrelloRepositoryFactory>().Create(Folder).Returns(repository);

            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public async Task GetList_InvalidBoardId_ReturnsNull()
        {
            var repository = Substitute.For<ITrelloRepository>();
            repository.GetBoard(BoardId).Returns(null as Board);
            this.GetDependency<ITrelloRepositoryFactory>().Create(Folder).Returns(repository);

            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.IsNull(actual);
        }

        #endregion
    }
}