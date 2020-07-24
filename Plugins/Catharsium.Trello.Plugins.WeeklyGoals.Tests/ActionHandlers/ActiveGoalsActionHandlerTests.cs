using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Trello.Plugins.WeeklyGoals.Tests.ActionHandlers
{
    [TestClass]
    public class ActiveGoalsActionHandlerTests : TestFixture<ActiveGoalsActionHandler>
    {
        [TestMethod]
        public void Run_()
        {
            this.Target.Run();
        }
    }
}