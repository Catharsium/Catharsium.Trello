using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Api.Client.Clients;
using Catharsium.Trello.Api.Client.Interfaces;
using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Console.ActionHandlers.SubActions;
using Catharsium.Trello.Core._Configuration;
using Catharsium.Trello.Data._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
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

            services.AddTrelloCore(configuration);
            services.AddTrelloApiClient(configuration);
            services.AddTrelloData(configuration);

            services.AddIoUtilities(configuration);
            services.AddConsoleIoUtilities(configuration);

            services.AddScoped<IActionHandler, BrowseActionHandler>();
            services.AddScoped<IActionHandler, CreateActionHandler>();
            services.AddScoped<IActionHandler, ImportActionHandler>();
            services.AddScoped<IChooseBoardActionHandler, ChooseBoardActionHandler>();
            services.AddScoped<IChooseCardActionHandler, ChooseCardActionHandler>();
            services.AddScoped<IChooseListActionHandler, ChooseListActionHandler>();

            services.AddSingleton<ITrelloRestClient, TrelloRestClient>(provider => new TrelloRestClient(
                new HttpClient(),
                provider.GetService<TrelloApiClientConfiguration>(),
                provider.GetService<IConsole>().AskForText("Enter your Trello Token:")
            ));

            return services;
        }
    }
}