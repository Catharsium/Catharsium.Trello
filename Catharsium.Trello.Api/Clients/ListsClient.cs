using AutoMapper;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class ListsClient : IListsClient
    {
        private readonly ITrelloRestClient trelloRestClient;
        private readonly IMapper mapper;


        public ListsClient(ITrelloRestClient trelloRestClient, IMapper mapper)
        {
            this.trelloRestClient = trelloRestClient;
            this.mapper = mapper;
        }


        public async Task<List> CreateNew(string name, string boardId, string sourceListId = null, string position = null)
        {
            var parameters = new Dictionary<string, object> {
                {"name", name},
                {"idBoard", boardId}
            };
            if (!string.IsNullOrWhiteSpace(sourceListId)) {
                parameters["idListSource"] = sourceListId;
            }

            if (!string.IsNullOrWhiteSpace(position)) {
                parameters["pos"] = position;
            }

            return this.mapper.Map<List>(
                await this.trelloRestClient.Post<ApiList>("lists", parameters)
            );
        }


        public async Task<string> GetBoard(string listId)
        {
            return await this.trelloRestClient.Get<string>($"lists/{listId}/board");
        }


        public async Task<Card[]> GetCards(string listId)
        {
            var result = await this.trelloRestClient.Get<ApiCard[]>($"lists/{listId}/cards");
            return this.mapper.Map<Card[]>(result);
        }
    }
}