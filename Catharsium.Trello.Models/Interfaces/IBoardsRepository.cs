using System.Collections.Generic;

namespace Catharsium.Trello.Models.Interfaces
{
    public interface IBoardsRepository
    {
        IEnumerable<Board> GetAll(string folder);
    }
}