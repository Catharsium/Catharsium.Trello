using Catharsium.Trello.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Console.ActionHandlers.Interfaces
{
    public interface IChooseListActionHandler
    {
        List Run(IEnumerable<List> boards);
    }
}