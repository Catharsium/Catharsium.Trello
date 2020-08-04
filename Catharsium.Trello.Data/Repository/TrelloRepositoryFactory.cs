using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.IO.Interfaces;
using System;

namespace Catharsium.Trello.Data.Repository
{
    public class TrelloRepositoryFactory : ITrelloRepositoryFactory
    {
        private readonly IServiceProvider serviceProvider;


        public TrelloRepositoryFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public ITrelloRepository Create(string folder)
        {
            return new TrelloRepository(
                folder,
                this.serviceProvider.GetService(typeof(IFileFactory)) as IFileFactory,
                this.serviceProvider.GetService(typeof(IJsonFileReader)) as IJsonFileReader,
                this.serviceProvider.GetService(typeof(IJsonFileWriter)) as IJsonFileWriter
            );
        }
    }
}