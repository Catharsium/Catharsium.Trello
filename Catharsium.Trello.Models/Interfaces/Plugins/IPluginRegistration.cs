using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Trello.Models.Interfaces.Plugins
{
    public interface IPluginRegistration
    {
        void RegisterDependencies(IServiceCollection services, IConfiguration configuration);
    }
}