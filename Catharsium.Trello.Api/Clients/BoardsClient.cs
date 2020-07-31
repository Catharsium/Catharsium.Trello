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
            var result = await this.trelloRestClient.Get<ApiBoard[]>("members/me/boards");
            return this.mapper.Map<Board[]>(result);
        }


        public async Task<Board> GetBoard(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiBoard>($"boards/{boardId}");
            return this.mapper.Map<Board>(result);
        }


        public async Task<List[]> GetLists(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiList[]>($"boards/{boardId}/lists");
            return this.mapper.Map<List[]>(result);
        }


        public async Task<Card[]> GetCards(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiCard[]>($"boards/{boardId}/cards");
            return this.mapper.Map<Card[]>(result);
        }


        public async Task<Action[]> GetActions(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiAction[]>($"boards/{boardId}/actions");
            return this.mapper.Map<Action[]>(result);
        }


        public async Task<Checklist[]> GetChecklists(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiChecklist[]>($"boards/{boardId}/checklists");
            return this.mapper.Map<Checklist[]>(result);
        }


        public async Task<Membership[]> GetMemberships(string boardId)
        {
            var result = await this.trelloRestClient.Get<ApiMembership[]>($"boards/{boardId}/memberships");
            return this.mapper.Map<Membership[]>(result);
        }
    }
}