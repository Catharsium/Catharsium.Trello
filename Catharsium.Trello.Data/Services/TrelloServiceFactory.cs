using Catharsium.Trello.Models.Interfaces.Data;
using System;

namespace Catharsium.Trello.Data.Services
{
    public class TrelloServiceFactory : ITrelloServiceFactory
    {
        private readonly IServiceProvider serviceProvider;


        public TrelloServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public ITrelloService Create(string folder)
        {
            return new TrelloService(
                folder,
                this.serviceProvider.GetService(typeof(ITrelloRepositoryFactory)) as ITrelloRepositoryFactory
            );
        }
    }
}