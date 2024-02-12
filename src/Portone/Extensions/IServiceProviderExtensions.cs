using Microsoft.Extensions.DependencyInjection;

using Portone.Client;

namespace Portone.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static IServiceCollection AddPortoneService(IServiceCollection services)
        {
            services.AddScoped<PortoneV2Client>();
            return services;
        }
    }
}