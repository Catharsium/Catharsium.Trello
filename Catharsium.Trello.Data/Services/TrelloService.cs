using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Services
{
    public class TrelloService : ITrelloService
    {
        private readonly ITrelloRepositoryFactory trelloRepositoryFactory;
        public string Location { get; }


        public TrelloService(string folder, ITrelloRepositoryFactory trelloRepositoryFactory)
        {
            this.Location = folder;
            this.trelloRepositoryFactory = trelloRepositoryFactory;
        }


        public Task<Board[]> GetBoards()
        {
            throw new System.NotImplementedException();
        }


        public async Task<Board> GetBoard(string boardIdOrName)
        {
            var repository = this.trelloRepositoryFactory.Create(this.Location);
            return await repository.GetBoard(boardIdOrName);
        }


        public async Task<List> GetList(string boardIdOrName, string listIdOrName)
        {
            var repository = this.trelloRepositoryFactory.Create(this.Location);
            var board = await repository.GetBoard(boardIdOrName);
            return board?.Lists.FirstOrDefault(l => l.Id == listIdOrName || l.Name == listIdOrName);
        }


        public async Task<Card> GetCard(string boardIdOrName, string cardIdOrName)
        {
            var repository = this.trelloRepositoryFactory.Create(this.Location);
            var board = await repository.GetBoard(boardIdOrName);
            return board?.Cards.FirstOrDefault(l => l.Id == cardIdOrName || l.Name == cardIdOrName);
        }


        public async Task<Label> GetLabel(string boardIdOrName, string labelIdOrColor)
        {
            var repository = this.trelloRepositoryFactory.Create(this.Location);
            var board = await repository.GetBoard(boardIdOrName);
            return board?.Labels.FirstOrDefault(l => l.Id == labelIdOrColor || l.Color == labelIdOrColor);
        }
    }
}