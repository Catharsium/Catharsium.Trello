using Catharsium.Trello.Console.ActionHandlers.SubActions;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Console.Tests.ActionHandlers.SubActions
{
    [TestClass]
    public class ChooseCardActionHandlerTests : TestFixture<ChooseCardActionHandler>
    {
        [TestMethod]
        public void Run_ValidSelectedCardIndex_ReturnsCard()
        {
            var index = 2;
            var cards = new[] {new Card(), new Card(), new Card()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(index);

            var actual = this.Target.Run(cards);
            Assert.AreEqual(cards[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoSelectedCardIndex_ReturnsNull()
        {
            var cards = new[] {new Card(), new Card(), new Card()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(null as int?);

            var actual = this.Target.Run(cards);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void Run_InvalidSelectedCardIndex_ReturnsNull()
        {
            var cards = new[] {new Card(), new Card(), new Card()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(cards.Length + 2);

            var actual = this.Target.Run(cards);
            Assert.IsNull(actual);
        }
    }
}