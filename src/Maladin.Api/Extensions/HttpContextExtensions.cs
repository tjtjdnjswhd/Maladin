using Microsoft.AspNetCore.Authentication;

namespace Maladin.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task<bool> IsAuthenticationSchemeExist(this HttpContext context, string schemeName)
        {
            return (await context.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetAllSchemesAsync()).Any(s => s.Name == schemeName);
        }
    }
}