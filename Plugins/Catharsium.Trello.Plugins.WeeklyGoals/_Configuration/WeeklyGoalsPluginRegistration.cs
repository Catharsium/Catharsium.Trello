using Catharsium.Trello.Models.Interfaces.Console;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.WeeklyGoals._Configuration
{
    public static class WeeklyGoalsPluginRegistration
    {
        public static IServiceCollection AddWeeklyGoalsPlugin(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<WeeklyGoalsPluginConfiguration>();
            services.AddSingleton<WeeklyGoalsPluginConfiguration, WeeklyGoalsPluginConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<IActionHandler, ActiveGoalsActionHandler>();
            services.AddScoped<IActionHandler, PlanningActionHandler>();

            return services;
        }
    }
}