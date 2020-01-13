using Catharsium.Trello.Models.Interfaces.Core;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Core._Configuration
{
    public static class TrelloCoreRegistration
    {
        public static IServiceCollection AddTrelloCore(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloCoreConfiguration>();
            services.AddSingleton<TrelloCoreConfiguration, TrelloCoreConfiguration>(provider => trelloCoreConfiguration);

            services.AddScoped<ICreationDateRetriever, CreationDateRetriever>();

            return services;
        }
    }
}