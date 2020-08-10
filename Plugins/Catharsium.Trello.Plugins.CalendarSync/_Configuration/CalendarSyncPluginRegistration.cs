using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.CalendarSync.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.CalendarSync._Configuration
{
    public class CalendarSyncPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<CalendarSyncPluginConfiguration>();
            services.AddSingleton<CalendarSyncPluginConfiguration, CalendarSyncPluginConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<IActionHandler, SyncBoardGamesActionHandler>();
        }
    }
}