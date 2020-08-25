using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface ITrelloRepository
    {
        string Location { get; set; }

        Task<IEnumerable<Board>> GetBoards();
        Task<Board> GetBoard(string idOrName);
        Task Store(Board board);
    }
}