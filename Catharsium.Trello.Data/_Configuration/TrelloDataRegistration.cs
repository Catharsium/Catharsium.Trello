using Catharsium.Trello.Data.Repository;
using Catharsium.Trello.Data.Services;
using Catharsium.Trello.Models.Interfaces.Data;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Data._Configuration
{
    public static class TrelloDataRegistration
    {
        public static IServiceCollection AddTrelloData(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloDataConfiguration>();
            services.AddSingleton<TrelloDataConfiguration, TrelloDataConfiguration>(provider => trelloCoreConfiguration);

            services.AddTransient<ITrelloRepositoryFactory, TrelloRepositoryFactory>();
            services.AddTransient<ITrelloServiceFactory, TrelloServiceFactory>();

            return services;
        }
    }
}