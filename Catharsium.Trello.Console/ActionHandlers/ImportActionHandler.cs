using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console._Configuration;
using Catharsium.Trello.Models.Interfaces.Api;
using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ImportActionHandler : IActionHandler
    {
        private readonly IBoardsClient boardsClient;
        private readonly IBoardsService boardsService;
        private readonly ITrelloRepositoryFactory boardsRepositoryFactory;
        private readonly TrelloConsoleConfiguration configuration;


        public ImportActionHandler(
            IBoardsClient boardsClient,
            IBoardsService boardsService,
            ITrelloRepositoryFactory boardsRepositoryFactory,
            TrelloConsoleConfiguration configuration)
        {
            this.boardsClient = boardsClient;
            this.boardsService = boardsService;
            this.boardsRepositoryFactory = boardsRepositoryFactory;
            this.configuration = configuration;
        }


        public string FriendlyName => "Import";


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            var repository = this.boardsRepositoryFactory.Create(this.configuration.RepositoryFolder);
            foreach (var boardId in boards.Select(b => b.Id)) {
                var board = await this.boardsService.GetBoard(boardId);
                await repository.Store(board);
            }
        }
    }
}