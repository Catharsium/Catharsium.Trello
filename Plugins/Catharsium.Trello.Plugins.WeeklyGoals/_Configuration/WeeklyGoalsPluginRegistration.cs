using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.WeeklyGoals._Configuration
{
    public class WeeklyGoalsPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.Load<WeeklyGoalsPluginConfiguration>();
            services.AddSingleton<WeeklyGoalsPluginConfiguration, WeeklyGoalsPluginConfiguration>(provider => config);

            services.AddScoped<IActionHandler, ActiveGoalsActionHandler>();
            services.AddScoped<IActionHandler, PlanningActionHandler>();
        }
    }
}