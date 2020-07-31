using System.Threading.Tasks;

namespace Catharsium.Trello.Models.Interfaces.Api
{
    public interface IBoardsService
    {
        Task<Board> GetBoard(string id);
    }
}