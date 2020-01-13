using Catharsium.Trello.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Console.Interfaces
{
    public interface IChooseBoardActionHandler
    {
        Board Run(IEnumerable<Board> boards);
    }
}