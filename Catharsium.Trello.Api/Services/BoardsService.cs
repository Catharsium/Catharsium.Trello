using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Api;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Services
{
    public class BoardsService : IBoardsService
    {
        private readonly IBoardsClient boardsClient;


        public BoardsService(IBoardsClient boardsClient)
        {
            this.boardsClient = boardsClient;
        }


        public async Task<Board> GetBoard(string id)
        {
            var board = await this.boardsClient.GetBoard(id);
            if (board == null) {
                return null;
            }

            var lists = await this.boardsClient.GetLists(board.Id);
            board.Lists.AddRange(lists);
            var cards = await this.boardsClient.GetCards(board.Id);
            board.Cards.AddRange(cards);
            var actions = await this.boardsClient.GetActions(board.Id);
            board.Actions.AddRange(actions);
            var checklists = await this.boardsClient.GetChecklists(board.Id);
            board.Checklists.AddRange(checklists);
            var labels = await this.boardsClient.GetLabels(board.Id);
            board.Labels.AddRange(labels);
            var memberships = await this.boardsClient.GetMemberships(board.Id);
            board.Memberships.AddRange(memberships);

            return board;
        }
    }
}