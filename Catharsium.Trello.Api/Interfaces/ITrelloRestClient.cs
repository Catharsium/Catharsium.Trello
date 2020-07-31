using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface ITrelloRestClient
    {
        Task<T> Get<T>(string path);
        Task<T> Post<T>(string path, Dictionary<string, object> data);
    }
}