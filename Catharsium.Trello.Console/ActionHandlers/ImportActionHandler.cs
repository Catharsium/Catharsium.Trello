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
        private readonly IBoardsRepository boardsRepository;
        private readonly TrelloConsoleConfiguration configuration;


        public ImportActionHandler(
            IBoardsClient boardsClient,
            IBoardsService boardsService,
            IBoardsRepository boardsRepository,
            TrelloConsoleConfiguration configuration)
        {
            this.boardsClient = boardsClient;
            this.boardsService = boardsService;
            this.boardsRepository = boardsRepository;
            this.configuration = configuration;
        }


        public string FriendlyName => "Import";


        public async Task Run()
        {
            var boards = await this.boardsClient.GetAll();
            foreach (var boardId in boards.Select(b => b.Id)) {
                var board = await this.boardsService.GetBoard(boardId);
                this.boardsRepository.Store(board, this.configuration.RepositoryFolder);
            }
        }
    }
}