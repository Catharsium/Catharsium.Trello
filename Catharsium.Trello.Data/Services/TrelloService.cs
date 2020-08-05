using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Trello.Data.Services
{
    public class TrelloService : ITrelloService
    {
        public string Location { get; }
        private readonly ITrelloRepositoryFactory trelloRepositoryFactory;


        public TrelloService(string folder, ITrelloRepositoryFactory trelloRepositoryFactory)
        {
            this.Location = folder;
            this.trelloRepositoryFactory = trelloRepositoryFactory;
        }


        public async Task<List> GetList(string boardIdOrName, string listIdOrName)
        {
            var repository = this.trelloRepositoryFactory.Create(this.Location);
            var board = await repository.GetBoard(boardIdOrName);
            return board?.Lists.FirstOrDefault(l => l.Id == listIdOrName || l.Name == listIdOrName);
        }
    }
}