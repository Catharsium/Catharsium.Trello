using Catharsium.Trello.Core.Filters;
using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Trello.Models.Interfaces.Core.Filters;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Catharsium.Trello.Core._Configuration
{
    public static class TrelloCoreRegistration
    {
        public static IServiceCollection AddTrelloCore(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloCoreConfiguration>();
            services.AddSingleton<TrelloCoreConfiguration, TrelloCoreConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<ICreationDateRetriever, CreationDateRetriever>();
            services.AddScoped<ICardFilterFactory, CardFilterFactory>();

            services.AddTransient(provider => {
                return new Func<DateTime, DateTime, ICreationDateFilter>(
                    (fromDate, toDate) => new CreationDateFilter(provider.GetService<ICreationDateRetriever>(), fromDate, toDate)
                );
            });
            services.AddTransient(provider => {
                return new Func<DateTime, DateTime, IDueDateFilter>(
                    (fromDate, toDate) => new DueDateFilter(fromDate, toDate)
                );
            });

            return services;
        }
    }
}