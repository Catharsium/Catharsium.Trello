using AutoMapper;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class CardsClient : ICardsClient
    {
        private readonly ITrelloRestClient trelloRestClient;
        private readonly IMapper mapper;


        public CardsClient(ITrelloRestClient trelloRestClient, IMapper mapper)
        {
            this.trelloRestClient = trelloRestClient;
            this.mapper = mapper;
        }


        public async Task<Card> CreateNew(string name, string boardId, string listId, string position = null, string[] labels = null)
        {
            var parameters = new Dictionary<string, object> {
                {"name", HttpUtility.UrlEncode(name)},
                {"idBoard", boardId},
                {"idList", listId}
            };

            if (!string.IsNullOrWhiteSpace(position)) {
                parameters["pos"] = position;
            }

            if (labels != null) {
                parameters["idLabels"] = string.Join(",", labels);
            }

            return this.mapper.Map<Card>(
                await this.trelloRestClient.Post<ApiCard>("cards", parameters)
            );
        }
    }
}