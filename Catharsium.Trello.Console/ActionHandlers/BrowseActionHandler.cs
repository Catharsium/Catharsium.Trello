using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class BrowseActionHandler : IActionHandler
    {
        private readonly IChooseBoardActionHandler chooseBoardActionHandler;


        public BrowseActionHandler(IChooseBoardActionHandler chooseBoardActionHandler)
        {
            this.chooseBoardActionHandler = chooseBoardActionHandler;
        }


        public string FriendlyName => "Browse";


        public async Task Run()
        {
            await this.chooseBoardActionHandler.Run();
        }
    }
}