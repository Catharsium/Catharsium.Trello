using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Console.ActionHandlers.SubActions
{
    public class ChooseBoardActionHandler : IChooseBoardActionHandler
    {
        private readonly IConsole console;


        public ChooseBoardActionHandler(IConsole console)
        {
            this.console = console;
        }


        public string FriendlyName => "Choose a board";


        public Board Run(IEnumerable<Board> boards)
        {
            var boardsArray = boards.ToArray();
            for (var i = 1; i <= boardsArray.Length; i++) {
                this.console.WriteLine($"[{i}] {boardsArray[i - 1]}");
            }

            var selectedIndex = this.console.AskForInt("Choose a board:");
            return selectedIndex != null && selectedIndex > 0 && selectedIndex <= boardsArray.Length
                ? boardsArray[selectedIndex.Value - 1]
                : null;
        }
    }
}