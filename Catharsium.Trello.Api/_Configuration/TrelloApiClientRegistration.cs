using AutoMapper;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
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

            services.AddScoped<IBoardsClient, BoardsClient>();

            services.AddAutoMapper(typeof(TrelloApiClientRegistration));

            return services;
        }
    }
}