using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Services;
using Catharsium.Trello.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Tests.Services
{
    [TestClass]
    public class BoardServiceTests : TestFixture<BoardsService>
    {
        #region Fixture

        public Board Board { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.Board = new Board {
                Id = "My board id",
                Name = "My board name"
            };
            this.GetDependency<IBoardsClient>().GetAll().Returns(new[] { this.Board });
            this.GetDependency<IBoardsClient>().GetBoard(this.Board.Id).Returns(this.Board);
        }


        #endregion

        #region GetBoard

        [TestMethod]
        public async Task GetBoard_InvalidId_ReturnsNull()
        {
            this.GetDependency<IBoardsClient>().GetBoard(this.Board.Id).Returns(null as Board);
            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsBoard()
        {
            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
        }


        [TestMethod]
        public async Task GetBoard_ValidName_ReturnsBoard()
        {
            var actual = await this.Target.GetBoard(this.Board.Name);
            Assert.AreEqual(this.Board, actual);
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsLists()
        {
            var lists = new[] {
                new List(), new List()
            };
            this.GetDependency<IBoardsClient>().GetLists(this.Board.Id).Returns(lists);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(lists.Length, actual.Lists.Count);
            foreach (var list in lists) {
                Assert.IsTrue(actual.Lists.Contains(list));
            }
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsCards()
        {
            var cards = new[] {
                new Card(), new Card()
            };
            this.GetDependency<IBoardsClient>().GetCards(this.Board.Id).Returns(cards);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(cards.Length, actual.Cards.Count);
            foreach (var card in cards) {
                Assert.IsTrue(actual.Cards.Contains(card));
            }
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsActions()
        {
            var actions = new[] {
                new Action(), new Action()
            };
            this.GetDependency<IBoardsClient>().GetActions(this.Board.Id).Returns(actions);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(actions.Length, actual.Actions.Count);
            foreach (var action in actions) {
                Assert.IsTrue(actual.Actions.Contains(action));
            }
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsChecklists()
        {
            var checklists = new[] {
                new Checklist(), new Checklist()
            };
            this.GetDependency<IBoardsClient>().GetChecklists(this.Board.Id).Returns(checklists);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(checklists.Length, actual.Checklists.Count);
            foreach (var checklist in checklists) {
                Assert.IsTrue(actual.Checklists.Contains(checklist));
            }
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsLabels()
        {
            var labels = new[] {
                new Label(), new Label()
            };
            this.GetDependency<IBoardsClient>().GetLabels(this.Board.Id).Returns(labels);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(labels.Length, actual.Labels.Count);
            foreach (var label in labels) {
                Assert.IsTrue(actual.Labels.Contains(label));
            }
        }


        [TestMethod]
        public async Task GetBoard_ValidId_ReturnsMemberships()
        {
            var memberships = new[] {
                new Membership(), new Membership()
            };
            this.GetDependency<IBoardsClient>().GetMemberships(this.Board.Id).Returns(memberships);

            var actual = await this.Target.GetBoard(this.Board.Id);
            Assert.AreEqual(this.Board, actual);
            Assert.AreEqual(memberships.Length, actual.Memberships.Count);
            foreach (var membership in memberships) {
                Assert.IsTrue(actual.Memberships.Contains(membership));
            }
        }

        #endregion
    }
}