using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.Groceries.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.Groceries._Configuration
{
    public class GroceriesPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<GroceriesPluginConfiguration>();
            services.AddSingleton<GroceriesPluginConfiguration, GroceriesPluginConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<IActionHandler, ScheduleActionHandler>();
        }
    }
}