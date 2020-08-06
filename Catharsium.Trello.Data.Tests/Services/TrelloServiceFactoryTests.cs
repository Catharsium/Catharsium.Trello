using System;
using Catharsium.Trello.Data.Services;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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
            var trelloRepositoryFactory = Substitute.For<ITrelloRepositoryFactory>();
            this.GetDependency<IServiceProvider>().GetService(typeof(ITrelloRepositoryFactory)).Returns(trelloRepositoryFactory);

            var actual = this.Target.Create(Folder);
            Assert.IsNotNull(actual);
            Assert.AreEqual(Folder, actual.Location);
        }
    }
}