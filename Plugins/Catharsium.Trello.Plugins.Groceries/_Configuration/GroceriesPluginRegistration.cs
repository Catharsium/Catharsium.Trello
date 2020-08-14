using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.Groceries.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.Groceries._Configuration
{
    public class GroceriesPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.Load<GroceriesPluginConfiguration>();
            services.AddSingleton<GroceriesPluginConfiguration, GroceriesPluginConfiguration>(provider => config);

            services.AddScoped<IActionHandler, ScheduleActionHandler>();
        }
    }
}