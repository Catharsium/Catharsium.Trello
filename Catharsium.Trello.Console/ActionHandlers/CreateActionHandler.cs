using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class CreateActionHandler : IActionHandler
    {
        private readonly IChooseBoardActionHandler chooseBoardActionHandler;
        private readonly IBoardsClient boardsClient;
        private readonly IListsClient listsClient;
        private readonly IConsole console;


        public CreateActionHandler(
            IChooseBoardActionHandler chooseBoardActionHandler,
            IBoardsClient boardsClient,
            IListsClient listsClient,
            IConsole console)
        {
            this.chooseBoardActionHandler = chooseBoardActionHandler;
            this.boardsClient = boardsClient;
            this.listsClient = listsClient;
            this.console = console;
        }


        public string FriendlyName => "Create";


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            var board = this.chooseBoardActionHandler.Run(boards);

            var name = this.console.AskForText("Enter the name of the list:");
            await this.listsClient.CreateNew(name, board.Id);
        }
    }
}