using Microsoft.Extensions.DependencyInjection;

using Portone.Client;

namespace Portone.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPortoneClient(this IServiceCollection services)
        {
            services.AddHttpClient<PortoneV2Client>();
            services.AddScoped<PortoneV2Client>();
            return services;
        }

        public static IServiceCollection AddPortoneClient(this IServiceCollection services, string name)
        {
            services.AddScoped<PortoneV2Client>();
            services.AddHttpClient<PortoneV2Client>(name);
            return services;
        }

        public static IServiceCollection AddPortoneClient(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            services.AddScoped<PortoneV2Client>();
            services.AddHttpClient<PortoneV2Client>(configureClient);
            return services;
        }

        public static IServiceCollection AddPortoneClient(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient)
        {
            services.AddScoped<PortoneV2Client>();
            services.AddHttpClient<PortoneV2Client>(configureClient);
            return services;
        }

        public static IServiceCollection AddPortoneClient(this IServiceCollection services, string name, Action<HttpClient> configureClient)
        {
            services.AddScoped<PortoneV2Client>();
            services.AddHttpClient<PortoneV2Client>(name, configureClient);
            return services;
        }


        public static IServiceCollection AddPortoneClient(this IServiceCollection services, string name, Action<IServiceProvider, HttpClient> configureClient)
        {
            services.AddScoped<PortoneV2Client>();
            services.AddHttpClient<PortoneV2Client>(name, configureClient);
            return services;
        }
    }
}