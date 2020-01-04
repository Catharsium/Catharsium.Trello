using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Core._Configuration
{
    public static class TrelloDataRegistration
    {
        public static IServiceCollection AddTrelloData(this IServiceCollection services, IConfiguration configuration)
        {
            var trelloCoreConfiguration = configuration.Load<TrelloDataConfiguration>();
            services.AddSingleton<TrelloDataConfiguration, TrelloDataConfiguration>(provider => trelloCoreConfiguration);

            return services;
        }
    }
}