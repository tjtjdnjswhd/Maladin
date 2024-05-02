using Maladin.Api.Constants;

using Microsoft.AspNetCore.Authorization;

namespace Maladin.Api
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public AdminAuthorizeAttribute() : base(AuthorizePolicy.ADMIN)
        {
        }
    }
}