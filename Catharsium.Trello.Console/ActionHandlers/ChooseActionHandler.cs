using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Util.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ChooseActionHandler : IChooseActionHandler
    {
        private readonly ITypesRetriever typesRetriever;
        private readonly List<IActionHandler> actionHandlers;
        private readonly IConsole console;


        public ChooseActionHandler(ITypesRetriever typesRetriever, IEnumerable<IActionHandler> actionHandlers, IConsole console)
        {
            this.typesRetriever = typesRetriever;
            this.actionHandlers = actionHandlers.ToList();
            this.console = console;
        }


        public async Task Run()
        {
            var index = 1;
            foreach (var action in this.actionHandlers) {
                this.console.WriteLine($"[{index++}] {action.FriendlyName}");
            }

            var selectedIndex = this.console.AskForInt("Please select an action:");
            if (selectedIndex.HasValue && selectedIndex > 0 && selectedIndex <= this.actionHandlers.Count) {
                await this.actionHandlers[selectedIndex.Value - 1].Run();
            }
        }
    }
}