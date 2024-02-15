using Microsoft.Extensions.DependencyInjection;

using Portone.Client;

namespace Portone.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPortoneClient(this IServiceCollection services)
        {
            services.AddScoped<PortoneV2Client>();
            return services;
        }
    }
}