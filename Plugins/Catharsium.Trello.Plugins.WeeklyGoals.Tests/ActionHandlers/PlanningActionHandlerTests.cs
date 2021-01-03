using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Trello.Plugins.WeeklyGoals._Configuration;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests.ActionHandlers
{
    [TestClass]
    public class PlanningActionHandlerTests : TestFixture<PlanningActionHandler>
    {
        #region Fixture

        private WeeklyGoalsPluginSettings Settings { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.Settings = new WeeklyGoalsPluginSettings
            {
                BoardId = "My board id"
            };
            this.SetDependency(this.Settings);
        }

        #endregion

        [TestMethod]
        public async Task Run_()
        {
            var board = new Board();
            this.GetDependency<IBoardsService>().GetBoard(this.Settings.BoardId).Returns(board);

          //  await this.Target.Run();
        }
    }
}