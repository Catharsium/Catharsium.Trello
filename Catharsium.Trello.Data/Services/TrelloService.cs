using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Services
{
    public class TrelloService : ITrelloService
    {
        private ITrelloRepository Repository { get; }
        public string Location { get; }


        public TrelloService(string folder, ITrelloRepositoryFactory trelloRepositoryFactory)
        {
            this.Location = folder;
            this.Repository = trelloRepositoryFactory.Create(folder);
        }



        public async Task<Board[]> GetBoards()
        {
            return (await this.Repository.GetBoards()).ToArray();
        }


        public async Task<Board> GetBoard(string boardIdOrName)
        {
            return await this.Repository.GetBoard(boardIdOrName);
        }


        public async Task<List> GetList(string boardIdOrName, string listIdOrName)
        {
            var board = await this.Repository.GetBoard(boardIdOrName);
            return board?.Lists.FirstOrDefault(l => l.Id == listIdOrName || l.Name == listIdOrName);
        }


        public async Task<Card> GetCard(string boardIdOrName, string cardIdOrName)
        {
            var board = await this.Repository.GetBoard(boardIdOrName);
            return board?.Cards.FirstOrDefault(l => l.Id == cardIdOrName || l.Name == cardIdOrName);
        }


        public async Task<Label> GetLabel(string boardIdOrName, string labelIdOrColor)
        {
            var board = await this.Repository.GetBoard(boardIdOrName);
            return board?.Labels.FirstOrDefault(l => l.Id == labelIdOrColor || l.Color == labelIdOrColor);
        }
    }
}