using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface ITrelloRestClient
    {
        Task<T> Get<T>(string path);
        Task<string> Post<T>(T data);
    }
}