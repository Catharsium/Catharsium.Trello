using Catharsium.Trello.Api.Client.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface IBoardsClient
    {
        Task<ApiBoard[]> GetList();
    }
}