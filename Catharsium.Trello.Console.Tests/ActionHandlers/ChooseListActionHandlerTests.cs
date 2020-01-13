using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Trello.Console.Tests.ActionHandlers
{
    [TestClass]
    public class ChooseListActionHandlerTests : TestFixture<ChooseListActionHandler>
    {
        [TestMethod]
        public void Run_ValidSelectedListIndex_ReturnsList()
        {
            var index = 2;
            var lists = new[] {new List(), new List(), new List()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(index);

            var actual = this.Target.Run(lists);
            Assert.AreEqual(lists[index - 1], actual);
        }


        [TestMethod]
        public void Run_NoSelectedListIndex_ReturnsNull()
        {
            var lists = new[] {new List(), new List(), new List()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(null as int?);

            var actual = this.Target.Run(lists);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void Run_InvalidSelectedListIndex_ReturnsNull()
        {
            var lists = new[] {new List(), new List(), new List()};
            this.GetDependency<IConsole>().AskForInt(Arg.Any<string>()).Returns(lists.Length + 2);

            var actual = this.Target.Run(lists);
            Assert.IsNull(actual);
        }
    }
}