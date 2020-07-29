using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers.Interfaces
{
    public interface IActionHandler
    {
        string FriendlyName { get; }

        Task Run();
    }
}