using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Core._Configuration;
using Catharsium.Trello.Data._Configuration;
using Catharsium.Util._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Catharsium.Trello.Console._Configuration
{
    public static class TrelloConsoleRegistration
    {
        public static IServiceCollection AddTrelloConsole(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloConsoleConfiguration>();
            services.AddSingleton<TrelloConsoleConfiguration, TrelloConsoleConfiguration>(_ => trelloCoreConfiguration);

            services.AddScoped<IChooseActionHandler, ChooseActionHandler>();
            services.AddScoped<IChooseBoardActionHandler, ChooseBoardActionHandler>();
            services.AddScoped<IActionHandler, BrowseActionHandler>();
            services.AddScoped<IChooseCardActionHandler, ChooseCardActionHandler>();
            services.AddScoped<IChooseListActionHandler, ChooseListActionHandler>();

            services.AddTransient<ITrelloRestClient, TrelloRestClient>(provider => new TrelloRestClient(
                new HttpClient(), 
                provider.GetService<TrelloApiClientConfiguration>(),
                provider.GetService<IConsole>().AskForText("Enter your Trello Token:")));

            services.AddTrelloCore(configuration);
            services.AddTrelloApiClient(configuration);
            services.AddTrelloData(configuration);

            services.AddCatharsiumUtilities(configuration);
            services.AddIoUtilities(configuration);

            return services;
        }
    }
}