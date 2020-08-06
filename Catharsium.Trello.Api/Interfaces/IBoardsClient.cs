using Catharsium.Trello.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface IBoardsClient
    {
        Task<Board[]> GetAll();
        Task<Board> GetBoard(string boardId);
        Task<List[]> GetLists(string boardId);
        Task<Card[]> GetCards(string boardId);
        Task<Action[]> GetActions(string boardId);
        Task<Checklist[]> GetChecklists(string boardId);
        Task<Label[]> GetLabels(string boardId);
        Task<Membership[]> GetMemberships(string boardId);
    }
}