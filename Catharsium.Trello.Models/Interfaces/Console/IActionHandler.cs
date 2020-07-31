using System.Threading.Tasks;

namespace Catharsium.Trello.Models.Interfaces.Console
{
    public interface IActionHandler
    {
        string FriendlyName { get; }

        Task Run();
    }
}