using Maladin.Services.Interfaces;
using Maladin.Services.Options;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Maladin.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtService(this IServiceCollection services, string securityAlgorithm, Func<string, SecurityKey> keyGenerator)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(securityAlgorithm);
            ArgumentNullException.ThrowIfNull(keyGenerator);

            services.AddScoped<IJwtService, JwtService>();
            services.AddOptions<JwtServiceOptions>()
                .Configure(o =>
                {
                    o.SecurityAlgorithm = securityAlgorithm;
                    o.GenerateSecurityKey = keyGenerator;
                });
            return services;
        }
    }
}