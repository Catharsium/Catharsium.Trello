using Catharsium.Trello.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface IBoardsClient
    {
        Task<Board[]> GetAll();
        Task<List[]> GetLists(string boardId);
    }
}