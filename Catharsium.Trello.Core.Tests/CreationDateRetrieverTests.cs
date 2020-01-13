using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Trello.Core.Tests
{
    [TestClass]
    public class CreationDateRetrieverTests : TestFixture<CreationDateRetriever>
    {
        [TestMethod]
        public void FindCreationDate_String_IdContainingTimestamp_ReturnsTimestamp()
        {
            var expected = new DateTime(2019, 9, 11, 19, 46, 10);
            var id = "5d794f02b7ccdd32955e5b04";

            var actual = this.Target.FindCreationDate(id);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FindCreationDate_Double_ValidSeconds_ReturnsEpochTimePlusSeconds()
        {
            var seconds = new TimeSpan(400, 23, 59, 58);
            var expected = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + seconds;

            var actual = this.Target.FindCreationDate(seconds.TotalSeconds);
            Assert.AreEqual(expected, actual);
        }
    }
}