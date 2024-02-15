using Maladin.Api.Constants;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;

using System.Security.Claims;

namespace Maladin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(MaladinDbContext dbContext, IOptions<JwtOptions> jwtOptions, IJwtService jwtService, IDistributedCache cache, ILogger<IdentityController> logger) : ControllerBase
    {
        private readonly MaladinDbContext _dbContext = dbContext;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IDistributedCache _cache = cache;
        private readonly ILogger<IdentityController> _logger = logger;

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OAuthLoginAsync([FromForm] string oauthProvider, [FromQuery] string returnUrl)
        {
            if (!(await HttpContext.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetAllSchemesAsync()).Any(s => s.Name == oauthProvider))
            {
                return BadRequest();
            }

            AuthenticationProperties authenticationProperties = new()
            {
                RedirectUri = Url.ActionLink("OAuthLogin", "Identity", new { returnUrl }),
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
            };

            return Challenge(authenticationProperties, oauthProvider);
        }

        [HttpGet("login")]
        [Authorize(AuthorizePolicyConstants.OAUTH)]
        public async Task<IActionResult> OAuthLoginAsync([FromQuery] string returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProvider = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (oauthProvider is null || nameIdentifier is null)
            {
                _logger.LogInformation("Login failed. wrong authorize. OAuthProvider: {oauthProvider}, NameIdentifier: {nameIdentifier}", oauthProvider, nameIdentifier);
                return BadRequest();
            }

            int providerId = await _dbContext.OAuthProviders.Where(o => o.Name == oauthProvider).Select(o => o.Id).FirstOrDefaultAsync(cancellationToken);
            if (providerId == default)
            {
                _logger.LogInformation("Login failed. OAuth provider not exist. Provider name: {oauthProvider}", oauthProvider);
                return BadRequest();
            }

            ClaimsIdentity identity;
            try
            {
                var query = await _dbContext.OAuthIds
                    .Where(o => o.Provider.Name == oauthProvider && o.NameIdentifier == nameIdentifier)
                    .Select(o => new { o.User, RoleName = o.User.Role.Name })
                    .FirstOrDefaultAsync(cancellationToken);

                if (query is null)
                {
                    return NotFound();
                }

                Claim[] claims = [
                    new Claim(JwtRegisteredClaimNames.Sub, query.User.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, query.User.Name),
                    new Claim(JwtRegisteredClaimNames.Email, query.User.Email),
                    new Claim(ClaimTypes.Role, query.RoleName)];

                identity = new(claims);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Login failed. exception throwed while query");
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            string accessToken = _jwtService.GenerateToken(identity, _jwtOptions.SecureKey, _jwtOptions.RefreshTokenExpiration, null);
            string refreshToken = _jwtService.GetRefreshToken(_jwtOptions.RefreshTokenByteLength);

            CookieOptions cookieOptions = new()
            {
                MaxAge = _jwtOptions.RefreshTokenExpiration,
                HttpOnly = true,
                Secure = true
            };

            Response.Cookies.Append(_jwtOptions.AccessTokenName, accessToken, cookieOptions);
            Response.Cookies.Append(_jwtOptions.RefreshTokenName, refreshToken, cookieOptions);

            await _cache.SetStringAsync(refreshToken, accessToken, new() { SlidingExpiration = _jwtOptions.RefreshTokenExpiration }, cancellationToken);
            return Ok();
        }

        [HttpGet("logout")]
        [Authorize(AuthorizePolicyConstants.USER)]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync(CancellationToken cancellationToken)
        {
            if (!Request.Cookies.TryGetValue(_jwtOptions.AccessTokenName, out var accessToken) || !Request.Cookies.TryGetValue(_jwtOptions.RefreshTokenName, out var refreshToken))
            {
                return BadRequest();
            }

            string? cachedAccessToken = await _cache.GetStringAsync(refreshToken, cancellationToken);
            if (cachedAccessToken != accessToken)
            {

            }
        }
    }
}