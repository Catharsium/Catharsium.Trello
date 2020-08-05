using Catharsium.Trello.Data.Services;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Trello.Data.Tests.Services
{
    [TestClass]
    public class TrelloServiceFactoryTests : TestFixture<TrelloServiceFactory>
    {
        #region Fixture

        public static readonly string Folder = "My folder";

        #endregion

        [TestMethod]
        public void Create_ValidLocation_ReturnsRepositoryForTheLocation()
        {
            var actual = this.Target.Create(Folder);
            Assert.IsNotNull(actual);
            Assert.AreEqual(Folder, actual.Location);
        }
    }
}