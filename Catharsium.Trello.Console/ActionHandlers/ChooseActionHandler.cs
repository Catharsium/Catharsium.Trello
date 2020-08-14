using Catharsium.Util.IO.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ChooseActionHandler : IChooseActionHandler
    {
        private readonly List<IActionHandler> actionHandlers;
        private readonly IConsole console;


        public ChooseActionHandler(IEnumerable<IActionHandler> actionHandlers, IConsole console)
        {
            this.actionHandlers = actionHandlers.ToList();
            this.console = console;
        }


        public async Task Run()
        {
            while (true) {
                var index = 1;
                foreach (var action in this.actionHandlers) {
                    this.console.WriteLine($"[{index++}] {action.FriendlyName}");
                }

                var selectedIndex = this.console.AskForInt("Please select an action:");
                if (!selectedIndex.HasValue || selectedIndex <= 0 && selectedIndex > this.actionHandlers.Count) {
                    break;
                }

                this.console.WriteLine();
                await this.actionHandlers[selectedIndex.Value - 1].Run();
                this.console.WriteLine();
            }
        }
    }
}