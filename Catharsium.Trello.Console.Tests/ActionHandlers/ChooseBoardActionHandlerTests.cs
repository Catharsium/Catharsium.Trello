using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Console.Tests.ActionHandlers
{
    [TestClass]
    public class ChooseBoardActionHandlerTests : TestFixture<ChooseBoardActionHandler>
    {
        [TestMethod]
        public void Run_ValidSelectedBoardIndex_ReturnsBoard()
        {
            var index = 2;
            var boards = new[] {new Board(), new Board(), new Board()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(index);

            var actual = this.Target.Run(boards);
            Assert.AreEqual(boards[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoSelectedBoardIndex_ReturnsNull()
        {
            var boards = new[] {new Board(), new Board(), new Board()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(null as int?);

            var actual = this.Target.Run(boards);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void Run_InvalidSelectedBoardIndex_ReturnsNull()
        {
            var boards = new[] {new Board(), new Board(), new Board()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(boards.Length + 2);

            var actual = this.Target.Run(boards);
            Assert.IsNull(actual);
        }
    }
}