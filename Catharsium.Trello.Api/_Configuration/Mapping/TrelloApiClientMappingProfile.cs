using AutoMapper;
using Catharsium.Trello.Api.Client.Models;
using Catharsium.Trello.Models;

namespace Catharsium.Trello.Api.Client._Configuration.Mapping
{
    public class TrelloApiClientMappingProfile : Profile
    {
        public TrelloApiClientMappingProfile()
        {
            this.CreateMap<ApiBoard, Board>();
            this.CreateMap<ApiList, List>();
        }
    }
}