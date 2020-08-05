using System.Threading.Tasks;

namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface ITrelloService
    {
        string Location { get; }

        Task<List> GetList(string boardIdOrName, string listIdOrName);
    }
}