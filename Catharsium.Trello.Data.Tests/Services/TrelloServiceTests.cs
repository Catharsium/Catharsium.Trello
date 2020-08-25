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
        private static string CardId => "My card id";
        private static string LabelId => "My label id";

        public ITrelloRepository Repository { get; set; }

        public Board Board { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.Board = new Board {
                Id = "My board id"
            };
            this.SetDependency(Folder, "folder");

            this.Repository = Substitute.For<ITrelloRepository>();
            this.Repository.GetBoards().Returns(new[] {this.Board});
            this.Repository.GetBoard(BoardId).Returns(this.Board);
            var factory = Substitute.For<ITrelloRepositoryFactory>();
            factory.Create(Folder).Returns(this.Repository);
            this.SetDependency(factory);
        }

        #endregion

        #region GetBoards

        [TestMethod]
        public async Task GetBoards_ReturnsResultFromRepository()
        {
            var actual = await this.Target.GetBoards();
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Length);
            Assert.AreEqual(this.Board, actual[0]);
        }

        #endregion

        #region GetBoard

        [TestMethod]
        public async Task GetBoard_ReturnsResultFromRepository()
        {
            var actual = await this.Target.GetBoard(BoardId);
            Assert.AreEqual(this.Board, actual);
        }

        #endregion

        #region GetList

        [TestMethod]
        public async Task GetList_ValidId_ReturnsListWithId()
        {
            this.Board.Lists = new List<List> {
                new List {Id = ListId}
            };
            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.AreEqual(this.Board.Lists[0], actual);
        }


        [TestMethod]
        public async Task GetList_ValidName_ReturnsListWithName()
        {
            this.Board.Lists = new List<List> {
                new List {Name = ListId}
            };
            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.AreEqual(this.Board.Lists[0], actual);
        }


        [TestMethod]
        public async Task GetList_InvalidListId_ReturnsNull()
        {
            this.Board.Lists = new List<List> {new List()};
            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public async Task GetList_InvalidBoardId_ReturnsNull()
        {
            var actual = await this.Target.GetList(BoardId, ListId);
            Assert.IsNull(actual);
        }

        #endregion

        #region GetCard

        [TestMethod]
        public async Task GetCard_ValidId_ReturnsCardWithId()
        {
            this.Board.Cards = new List<Card> {
                new Card {Id = CardId}
            };
            var actual = await this.Target.GetCard(BoardId, CardId);
            Assert.AreEqual(this.Board.Cards[0], actual);
        }


        [TestMethod]
        public async Task GetCard_ValidColor_ReturnsCardWithName()
        {
            this.Board.Cards = new List<Card> {
                new Card {Name = CardId}
            };
            var actual = await this.Target.GetCard(BoardId, CardId);
            Assert.AreEqual(this.Board.Cards[0], actual);
        }


        [TestMethod]
        public async Task GetCard_InvalidListId_ReturnsNull()
        {
            this.Board.Cards = new List<Card> {new Card()};
            var actual = await this.Target.GetCard(BoardId, CardId);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public async Task GetCard_InvalidBoardId_ReturnsNull()
        {
            var actual = await this.Target.GetCard(BoardId, CardId);
            Assert.IsNull(actual);
        }

        #endregion

        #region GetLabel

        [TestMethod]
        public async Task GetLabel_ValidId_ReturnsLabelWithId()
        {
            this.Board.Labels = new List<Label> {
                new Label {Id = LabelId}
            };
            var actual = await this.Target.GetLabel(BoardId, LabelId);
            Assert.AreEqual(this.Board.Labels[0], actual);
        }


        [TestMethod]
        public async Task GetLabel_ValidColor_ReturnsLabelWithColor()
        {
            this.Board.Labels = new List<Label> {
                new Label {Color = LabelId}
            };
            var actual = await this.Target.GetLabel(BoardId, LabelId);
            Assert.AreEqual(this.Board.Labels[0], actual);
        }


        [TestMethod]
        public async Task GetLabel_InvalidListId_ReturnsNull()
        {
            this.Board.Labels = new List<Label> {new Label()};
            var actual = await this.Target.GetLabel(BoardId, LabelId);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public async Task GetLabel_InvalidBoardId_ReturnsNull()
        {
            var actual = await this.Target.GetLabel(BoardId, LabelId);
            Assert.IsNull(actual);
        }

        #endregion
    }
}