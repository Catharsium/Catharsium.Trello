using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests.ActionHandlers
{
    [TestClass]
    public class ActiveGoalsActionHandlerTests : TestFixture<ActiveGoalsActionHandler>
    {
        [TestMethod]
        public async Task Run_()
        {
            await this.Target.Run();
        }
    }
}