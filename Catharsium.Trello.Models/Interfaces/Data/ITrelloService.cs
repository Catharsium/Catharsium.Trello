using System.Threading.Tasks;

namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface ITrelloService
    {
        string Location { get; }

        Task<Board[]> GetBoards();
        Task<Board> GetBoard(string boardIdOrName);
        Task<List> GetList(string boardIdOrName, string listIdOrName);
        Task<Card> GetCard(string boardIdOrName, string cardIdOrName);
        Task<Label> GetLabel(string boardIdOrName, string labelIdOrColor);
    }
}