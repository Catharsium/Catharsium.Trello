using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Console.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ImportActionHandler : IActionHandler
    {
        private readonly IBoardsClient boardsClient;
        private readonly IBoardsService boardsService;
        private readonly ITrelloRepositoryFactory boardsRepositoryFactory;
        private readonly IConsole console;
        private readonly TrelloConsoleConfiguration configuration;

        public string FriendlyName => "Import";


        public ImportActionHandler(
            IBoardsClient boardsClient,
            IBoardsService boardsService,
            ITrelloRepositoryFactory boardsRepositoryFactory,
            IConsole console,
            TrelloConsoleConfiguration configuration)
        {
            this.boardsClient = boardsClient;
            this.boardsService = boardsService;
            this.boardsRepositoryFactory = boardsRepositoryFactory;
            this.console = console;
            this.configuration = configuration;
        }


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            this.console.WriteLine($"Found {boards.Length} boards");

            var selectedBoard = this.console.AskForItem(boards);
            var repository = this.boardsRepositoryFactory.Create(this.configuration.RepositoryFolder);
            if (selectedBoard == null) {
                foreach (var boardId in boards.Select(b => b.Id)) {
                    await this.ImportBoard(repository, boardId);
                }
            }
            else {
                await this.ImportBoard(repository, selectedBoard.Id);
            }
        }


        private async Task ImportBoard(ITrelloRepository repository, string boardId)
        {
            var board = await this.boardsService.GetBoard(boardId);
            this.console.WriteLine($"Saving board: {board}");
            await repository.Store(board);
        }
    }
}