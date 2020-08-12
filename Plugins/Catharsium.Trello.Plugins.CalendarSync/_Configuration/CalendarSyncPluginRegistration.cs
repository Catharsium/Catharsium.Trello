using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Data.Google._Configuration;
using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.CalendarSync.ActionHandlers;
using Catharsium.Trello.Plugins.CalendarSync.Interfaces;
using Catharsium.Trello.Plugins.CalendarSync.Parsers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.CalendarSync._Configuration
{
    public class CalendarSyncPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.Load<CalendarSyncPluginConfiguration>();
            services.AddSingleton<CalendarSyncPluginConfiguration, CalendarSyncPluginConfiguration>(provider => config);

            services.AddScoped<IActionHandler, SyncBoardGamesActionHandler>();

            services.AddScoped<IBoardGameEventService, BoardGameEventService>();

            services.AddGoogleCalendar(configuration);
            services.AddCalendarCoreLogic(configuration);
        }
    }
}