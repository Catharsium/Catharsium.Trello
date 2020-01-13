using Catharsium.Trello.Console.ActionHandlers;
using Catharsium.Trello.Console.Interfaces;
using Catharsium.Trello.Core._Configuration;
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
            services.AddSingleton<TrelloConsoleConfiguration, TrelloConsoleConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<IChooseBoardActionHandler, ChooseBoardActionHandler>();

            services.AddTrelloCore(configuration);
            services.AddTrelloData(configuration);

            services.AddIoUtilities(configuration);

            return services;
        }
    }
}