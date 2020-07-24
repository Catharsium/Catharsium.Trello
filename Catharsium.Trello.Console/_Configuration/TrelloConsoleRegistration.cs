using Catharsium.Trello.Api.Client._Configuration;
using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Core._Configuration;
using Catharsium.Trello.Data._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Console._Configuration
{
    public static class TrelloConsoleRegistration
    {
        public static IServiceCollection AddTrelloConsole(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloConsoleConfiguration>();
            services.AddSingleton<TrelloConsoleConfiguration, TrelloConsoleConfiguration>(_ => trelloCoreConfiguration);

            services.AddScoped<IChooseBoardActionHandler, ChooseBoardActionHandler>();
            services.AddScoped<IChooseCardActionHandler, ChooseCardActionHandler>();
            services.AddScoped<IChooseListActionHandler, ChooseListActionHandler>();

            services.AddTrelloCore(configuration);
            services.AddTrelloApiClient(configuration);
            services.AddTrelloData(configuration);

            services.AddIoUtilities(configuration);

            return services;
        }
    }
}