using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Trello.Plugins.CalendarSync.Parsers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Trello.Plugins.CalendarSync.Tests.Parsers
{
    [TestClass]
    public class BoardGameActivityEventParserTests : TestFixture<BoardGameActivityEventParser>
    {
        #region CanParse

        [TestMethod]
        public void CanParse_DescriptionStartsWithBoardGame_ReturnsTrue()
        {
            var @event = new Event {Description = "Board game (My Game)"};
            var actual = this.Target.CanParse(@event);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void CanParse_DescriptionContainsSomethingElse_ReturnsFalse()
        {
            var @event = new Event {Description = "Board something else (My Game)"};
            var actual = this.Target.CanParse(@event);
            Assert.IsFalse(actual);
        }

        #endregion

        #region

        [TestMethod]
        public void Parse_ValidEvent_ReturnsActivityEvent()
        {
            var activityName = "My activity";
            var @event = new Event {Description = $"Board game ({activityName})"};

            var actual = this.Target.Parse(@event);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Board game", actual.ActivityGroupName);
            Assert.AreEqual(activityName, actual.ActivityName);
        }


        [TestMethod]
        public void Parse_InvalidName_ReturnsActivityEvent()
        {
            var activityName = "My activity";
            var @event = new Event {Description = $"Board something else ({activityName})"};

            var actual = this.Target.Parse(@event);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Board game", actual.ActivityGroupName);
            Assert.AreEqual(activityName, actual.ActivityName);
        }


        [TestMethod]
        public void Parse_NoActivityName_ReturnsEventWithoutActivityName()
        {
            var @event = new Event {Description = "Board game"};
            var actual = this.Target.Parse(@event);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Board game", actual.ActivityGroupName);
            Assert.AreEqual("", actual.ActivityName);
        }

        #endregion
    }
}