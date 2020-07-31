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
            this.CreateMap<ApiCard, Card>();

            this.CreateMap<ApiPreferences, Preferences>();
            this.CreateMap<ApiImage, Image>();
            this.CreateMap<ApiAction, Action>();
            this.CreateMap<ApiChecklist, Checklist>();
            this.CreateMap<ApiMembership, Membership>();

            this.CreateMap<ApiLabel, Label>();
        }
    }
}