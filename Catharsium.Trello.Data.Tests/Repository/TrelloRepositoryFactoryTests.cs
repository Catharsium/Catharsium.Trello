using Catharsium.Trello.Data.Repository;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Trello.Data.Tests.Repository
{
    [TestClass]
    public class TrelloRepositoryFactoryTests : TestFixture<TrelloRepositoryFactory>
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