using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;

namespace Maladin.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task<bool> IsAuthenticationSchemeExist(this HttpContext context, string schemeName)
        {
            return (await context.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetAllSchemesAsync()).Any(s => s.Name == schemeName);
        }

        public static async Task<string?> GetDefaultAuthenticationSchemeAsync(this HttpContext context)
        {
            return (await context.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetDefaultAuthenticateSchemeAsync())?.Name;
        }

        public static bool TryGetUserId(this HttpContext context, out int userId)
        {
            if (!context.User.IsAuthenticated())
            {
                userId = -1;
                return false;
            }

            using var scope = context.RequestServices.CreateScope();
            IJwtService jwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();
            return jwtService.TryGetUserId(context.User.Claims, out userId);
        }
    }
}