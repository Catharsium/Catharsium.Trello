using AutoMapper;
using Catharsium.Trello.Api.Client.Interfaces;

namespace Catharsium.Trello.Api.Client.Clients
{
    public class LabelsClient : ILabelsClient
    {
        private readonly ITrelloRestClient trelloRestClient;
        private readonly IMapper mapper;


        public LabelsClient(ITrelloRestClient trelloRestClient, IMapper mapper)
        {
            this.trelloRestClient = trelloRestClient;
            this.mapper = mapper;
        }
    }
}