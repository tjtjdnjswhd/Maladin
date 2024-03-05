using Maladin.Api.Constants;

using System.Security.Claims;

namespace Maladin.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAuthenticated(this ClaimsPrincipal user)
        {
            return user.Identity?.IsAuthenticated ?? false;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AuthorizeRole.Admin);
        }
    }
}