using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Api.Client._Configuration
{
    public static class TrelloApiClientRegistration
    {
        public static IServiceCollection AddTrelloApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloApiClientConfiguration>();
            services.AddSingleton<TrelloApiClientConfiguration, TrelloApiClientConfiguration>(_ => trelloCoreConfiguration);

            services.AddTransient<ITrelloRestClient, TrelloRestClient>();

            return services;
        }
    }
}