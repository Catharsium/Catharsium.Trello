using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class BoardsClient : IBoardsClient
    {
        private readonly ITrelloRestClient trelloRestClient;


        public BoardsClient(ITrelloRestClient trelloRestClient)
        {
            this.trelloRestClient = trelloRestClient;
        }


        public async Task<ApiBoard[]> GetList()
        {
            return await this.trelloRestClient.Get<ApiBoard[]>("boards");
        }
    }
}