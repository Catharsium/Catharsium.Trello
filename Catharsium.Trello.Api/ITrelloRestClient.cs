using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client
{
    public interface ITrelloRestClient
    {
        Task Get(string token);
    }
}