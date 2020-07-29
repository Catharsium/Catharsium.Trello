﻿using Catharsium.Trello.Models;
using System.Collections.Generic;

namespace Catharsium.Trello.Console.ActionHandlers.Interfaces
{
    public interface IChooseBoardActionHandler : IActionHandler
    {
        Board Run(IEnumerable<Board> cards);
    }
}