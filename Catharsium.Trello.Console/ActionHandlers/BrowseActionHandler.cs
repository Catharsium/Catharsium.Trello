using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Models.Interfaces.Console;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class BrowseActionHandler : IActionHandler
    {
        private readonly IBoardsClient boardsClient;
        private readonly IChooseBoardActionHandler chooseBoardActionHandler;
        private readonly IChooseListActionHandler chooseListActionHandler;


        public BrowseActionHandler(
            IBoardsClient boardsClient,
            IChooseBoardActionHandler chooseBoardActionHandler,
            IChooseListActionHandler chooseListActionHandler)
        {
            this.boardsClient = boardsClient;
            this.chooseBoardActionHandler = chooseBoardActionHandler;
            this.chooseListActionHandler = chooseListActionHandler;
        }


        public string FriendlyName => "Browse";


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            var selectedBoard = this.chooseBoardActionHandler.Run(boards);
            var lists = await this.boardsClient.GetLists(selectedBoard.Id);
            var selectedList = this.chooseListActionHandler.Run(lists);
        }
    }
}