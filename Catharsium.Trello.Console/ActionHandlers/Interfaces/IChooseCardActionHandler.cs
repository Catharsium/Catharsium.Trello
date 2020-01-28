using Catharsium.Trello.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Console.ActionHandlers.Interfaces
{
    public interface IChooseCardActionHandler
    {
        Card Run(IEnumerable<Card> boards);
    }
}