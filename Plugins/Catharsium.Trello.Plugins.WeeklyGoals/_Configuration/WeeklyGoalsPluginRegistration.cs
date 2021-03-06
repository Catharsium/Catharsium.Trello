﻿using Catharsium.Trello.Models.Interfaces.Plugins;
using Catharsium.Trello.Plugins.WeeklyGoals.ActionHandlers;
using Catharsium.Trello.Plugins.WeeklyGoals.Interfaces;
using Catharsium.Trello.Plugins.WeeklyGoals.Logic;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Plugins.WeeklyGoals._Configuration
{
    public class WeeklyGoalsPluginRegistration : IPluginRegistration
    {
        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.Load<WeeklyGoalsPluginSettings>();
            services.AddSingleton<WeeklyGoalsPluginSettings, WeeklyGoalsPluginSettings>(provider => config);

            services.AddScoped<IActionHandler, ActiveGoalsActionHandler>();
            services.AddScoped<IActionHandler, AutoRenamerActionHandler>();
            services.AddScoped<IActionHandler, PlanningActionHandler>();
            services.AddScoped<IActionHandler, ChecklistGeneratorActionHandler>();

            services.AddScoped<IPlanningCreator, PlanningCreator>();
            services.AddScoped<IDatePatternResolver, DatePatternResolver>();
        }
    }
}