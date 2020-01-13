﻿using System.Collections.Generic;

namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface IBoardsRepository
    {
        IEnumerable<Board> GetAll(string folder);
    }
}