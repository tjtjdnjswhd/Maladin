using Maladin.Api.Constants;

using Microsoft.AspNetCore.Authorization;

namespace Maladin.Api
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public UserAuthorizeAttribute() : base(AuthorizePolicy.USER)
        {
        }
    }
}