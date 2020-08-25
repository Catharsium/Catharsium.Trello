using System;
using System.Collections.Generic;
using System.Text;
using Catharsium.Trello.Models.Interfaces.Data;

namespace Catharsium.Trello.Core.Services
{
    public class ImportService
    {
        private readonly ITrelloRepositoryFactory trelloRepositoryFactory;


        public ImportService(ITrelloRepositoryFactory trelloRepositoryFactory)
        {
            this.trelloRepositoryFactory = trelloRepositoryFactory;
        }
    }
}