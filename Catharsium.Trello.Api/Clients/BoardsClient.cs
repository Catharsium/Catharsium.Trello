using AutoMapper;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class BoardsClient : IBoardsClient
    {
        private readonly ITrelloRestClient trelloRestClient;
        private readonly IMapper mapper;


        public BoardsClient(ITrelloRestClient trelloRestClient, IMapper mapper)
        {
            this.trelloRestClient = trelloRestClient;
            this.mapper = mapper;
        }


        public async Task<Board[]> GetAll()
        {
            return this.mapper.Map<Board[]>(
                await this.trelloRestClient.Get<ApiBoard[]>("boards")
            );
        }


        public async Task<List[]> GetLists(string boardId)
        {
            return this.mapper.Map<List[]>(
                await this.trelloRestClient.Get<ApiList[]>($"boards/{boardId}/lists")
            );
        }
    }
}