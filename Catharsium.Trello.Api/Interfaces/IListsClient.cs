using Catharsium.Trello.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface IListsClient
    {
        Task<List> CreateNew(string name, string boardId, string sourceListId = null, string position = null);
        Task<string> GetBoard(string listId);
        Task<Card[]> GetCards(string listId);
    }
}