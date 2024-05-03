using Maladin.Api.Constants;

using Microsoft.AspNetCore.Authorization;

namespace Maladin.Api
{
    public class OAuthAuthorizeAttribute : AuthorizeAttribute
    {
        public OAuthAuthorizeAttribute() : base(AuthorizePolicy.OAUTH)
        {
        }
    }
}