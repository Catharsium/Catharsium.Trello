using Catharsium.Trello.Core.Filters.Extensions;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;

namespace Catharsium.Trello.Core.Tests.Filters.Extensions
{
    [TestClass]
    public class FilterExtensionsTests
    {
        #region Include

        [TestMethod]
        public void Include_FilterIncludingEverything_ReturnsAll()
        {
            var cards = new[] {new Card()};
            var filter = Substitute.For<ICardFilter>();
            filter.Includes(Arg.Any<Card>()).Returns(true);

            var actual = cards.Include(filter);
            Assert.AreEqual(cards.Length, actual.Count());
        }


        [TestMethod]
        public void Include_FilterIncludingNothing_ReturnsNothing()
        {
            var cards = new[] {new Card()};
            var filter = Substitute.For<ICardFilter>();
            filter.Includes(Arg.Any<Card>()).Returns(false);

            var actual = cards.Include(filter);
            Assert.AreEqual(0, actual.Count());
        }

        #endregion

        #region Exclude

        [TestMethod]
        public void Exclude_FilterIncludingEverything_ReturnsNothing()
        {
            var cards = new[] {new Card()};
            var filter = Substitute.For<ICardFilter>();
            filter.Includes(Arg.Any<Card>()).Returns(true);

            var actual = cards.Exclude(filter);
            Assert.AreEqual(0, actual.Count());
        }


        [TestMethod]
        public void Exclude_FilterIncludingNothing_ReturnsAll()
        {
            var cards = new[] {new Card()};
            var filter = Substitute.For<ICardFilter>();
            filter.Includes(Arg.Any<Card>()).Returns(false);

            var actual = cards.Exclude(filter);
            Assert.AreEqual(cards.Length, actual.Count());
        }

        #endregion
    }
}