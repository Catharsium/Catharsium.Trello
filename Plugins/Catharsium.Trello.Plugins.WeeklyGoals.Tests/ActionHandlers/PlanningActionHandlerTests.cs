using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests.ActionHandlers
{
    [TestClass]
    public class PlanningActionHandlerTests : TestFixture<PlanningActionHandler>
    {
        #region Fixture

        private TrelloConsoleConfiguration Configuration { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.Configuration = new TrelloConsoleConfiguration {
                RepositoryFolder = "My repository folder"
            };
            this.SetDependency(this.Configuration);
        }

        #endregion

        [TestMethod]
        public async Task Run_()
        {
            var boards = new List<Board>();
            var repository = Substitute.For<ITrelloRepository>();
            repository.GetBoards().Returns(boards);
            this.GetDependency<ITrelloRepositoryFactory>().Create(this.Configuration.RepositoryFolder).Returns(repository);

            await this.Target.Run();
        }
    }
}