using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ChooseBoardActionHandler : IChooseBoardActionHandler
    {
        private readonly IBoardsClient boardsClient;
        private readonly IConsole console;


        public ChooseBoardActionHandler(IBoardsClient boardsClient, IConsole console)
        {
            this.boardsClient = boardsClient;
            this.console = console;
        }


        public string FriendlyName => "Choose a board";


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            var selectedBoard = this.Run(boards);
        }


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