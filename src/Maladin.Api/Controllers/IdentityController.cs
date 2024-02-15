using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
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
        public async Task<IActionResult> OAuthLoginAsync([FromForm] string oauthProvider, [FromQuery] string? returnUrl)
        {
            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProvider))
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
        public async Task<IActionResult> OAuthLoginAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProvider = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _logger.LogInformation("Begin login");
            _logger.LogInformation("OAuthProvider: {oauthProvider}, NameIdentifier: {nameIdentifier}", oauthProvider, nameIdentifier);
            if (oauthProvider is null || nameIdentifier is null)
            {
                return Unauthorized();
            }

            ClaimInfo? claimInfo;
            try
            {
                claimInfo = await _dbContext.OAuthIds
                    .Where(o => o.Provider.Name == oauthProvider && o.NameIdentifier == nameIdentifier)
                    .Select(o => new ClaimInfo() { UserId = o.UserId, UserName = o.User.Name, UserEmail = o.User.Email, RoleName = o.User.Role.Name })
                    .FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextQueryException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            if (claimInfo is null)
            {
                return NotFound();
            }

            Claim[] claims = GetClaims(claimInfo);
            ClaimsIdentity identity = new(claims);

            string accessToken = _jwtService.GenerateToken(identity, _jwtOptions.SecureKey, _jwtOptions.RefreshTokenExpiration, null);
            string refreshToken = _jwtService.GetRefreshToken(_jwtOptions.RefreshTokenByteLength);

            CookieOptions cookieOptions = new()
            {
                MaxAge = _jwtOptions.RefreshTokenExpiration,
                HttpOnly = true,
                Secure = true
            };

            try
            {
                await _cache.SetStringAsync(refreshToken, accessToken, new() { SlidingExpiration = _jwtOptions.RefreshTokenExpiration }, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDistributedCacheException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            int updatedRowCount;
            try
            {
                updatedRowCount = await _dbContext.Users
                    .Where(u => u.Id == claimInfo.UserId)
                    .ExecuteUpdateAsync(set =>
                        set.SetProperty(u => u.LastLoginIp, HttpContext.Connection.RemoteIpAddress)
                        .SetProperty(u => u.LastLoginDate, DateTimeOffset.UtcNow),
                        cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextSaveException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            if (updatedRowCount == 0)
            {
                _logger.LogInformation("UserId {userId} not exist", claimInfo.UserId);
                return Conflict();
            }

            Response.Cookies.Append(_jwtOptions.AccessTokenName, accessToken, cookieOptions);
            Response.Cookies.Append(_jwtOptions.RefreshTokenName, refreshToken, cookieOptions);

            _logger.LogInformation("Login success. UserId: {userId}", claimInfo.UserId);
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpGet("logout")]
        [Authorize(AuthorizePolicyConstants.USER)]
        public async Task<IActionResult> LogoutAsync()
        {
            _logger.LogInformation("User logout. UserId: {userId}", User.FindFirstValue(JwtRegisteredClaimNames.Sub));
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin refresh");
            if (Request.Cookies[_jwtOptions.AccessTokenName] is not string accessToken || Request.Cookies[_jwtOptions.RefreshTokenName] is not string refreshToken)
            {
                _logger.LogInformation("Token not exist");
                Response.Headers.Append("REFRESH-TOKEN-EXPIRED", StringValues.Empty);
                return BadRequest();
            }

            string? cachedAccessToken = await _cache.GetStringAsync(refreshToken, cancellationToken);
            if (cachedAccessToken != accessToken)
            {
                _logger.LogInformation("Invalid refresh token");
                return Unauthorized();
            }

            if (!_jwtService.TryGetToken(cachedAccessToken, out var jwtSecurityToken))
            {
                _logger.LogWarning("Invalid cached access token. CachedAccessToken: {cachecAccessToken}, RefreshToken: {refreshToken}", cachedAccessToken, refreshToken);
                return BadRequest();
            }

            if (!int.TryParse(jwtSecurityToken.Subject, out int userId))
            {
                _logger.LogWarning("Invalid subject value. value: {sub}", jwtSecurityToken.Subject);
                return BadRequest();
            }

            ClaimInfo? claimInfo;
            try
            {
                claimInfo = await _dbContext.Users
                   .Where(u => u.Id == userId)
                   .Select(u => new ClaimInfo() { UserId = u.Id, UserEmail = u.Email, UserName = u.Name, RoleName = u.Role.Name })
                   .FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextQueryException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            if (claimInfo is null)
            {
                _logger.LogInformation("User not exist. UserId: {userId}", userId);
                return NotFound();
            }

            Claim[] claims = GetClaims(claimInfo);
            ClaimsIdentity identity = new(claims);

            string newAccessToken = _jwtService.GenerateToken(identity, _jwtOptions.SecureKey, _jwtOptions.RefreshTokenExpiration, null);
            string newRefreshToken = _jwtService.GetRefreshToken(_jwtOptions.RefreshTokenByteLength);

            try
            {
                await _cache.RemoveAsync(refreshToken, cancellationToken);
                await _cache.SetStringAsync(refreshToken, accessToken, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDistributedCacheException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignupAsync([FromQuery] string oauthProvider, [FromQuery] string name, [FromQuery] string? returnUrl)
        {
            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProvider))
            {
                return BadRequest();
            }

            AuthenticationProperties authenticationProperties = new()
            {
                RedirectUri = Url.ActionLink("OAuthSignup", "Identity", new { returnUrl }),
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
            };

            authenticationProperties.Items.Add("name", name);
            return Challenge(authenticationProperties, oauthProvider);
        }

        [HttpGet("signup")]
        [Authorize(AuthorizePolicyConstants.OAUTH)]
        public async Task<IActionResult> SignupAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProvider = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string? email = User.FindFirstValue(ClaimTypes.Email);

            _logger.LogInformation("Begin signup");
            _logger.LogOAuthInfo(oauthProvider, nameIdentifier);
            AuthenticationProperties? authenticationProperties = (await HttpContext.AuthenticateAsync(oauthProvider)).Properties;
            if (oauthProvider is null || nameIdentifier is null || email is null || authenticationProperties is null || !authenticationProperties.Items.TryGetValue("name", out string? userName))
            {
                _logger.LogInformation("Invalid signup info. Email: {email}", email);
                return Unauthorized();
            }

            bool isNameIdentifierDuplicate = await _dbContext.OAuthIds.AnyAsync(o => o.Provider.Name == oauthProvider && o.NameIdentifier == nameIdentifier, cancellationToken);
            if (isNameIdentifierDuplicate)
            {
                //TODO: return with duplicated nameIdentifier message
                _logger.LogInformation("Duplicated nameIdentifier");
                return BadRequest();
            }

            bool isUserNameDuplicated = await _dbContext.Users.AnyAsync(u => u.Name == userName, cancellationToken);
            if (isUserNameDuplicated)
            {
                //TODO: return with duplicated userName message
                _logger.LogInformation("Duplicated userName");
                return BadRequest();
            }

            int roleId = await _dbContext.Roles.OrderBy(r => r.Priority).Select(r => r.Priority).FirstOrDefaultAsync(cancellationToken);
            int membershipId = await _dbContext.Memberships.OrderBy(r => r.Level).Select(r => r.Level).FirstOrDefaultAsync(cancellationToken);
            if (roleId == default || membershipId == default)
            {
                _logger.LogError("Membership or Role from DB not exist");
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            EFCore.Models.User user = new(userName!, email, HttpContext.Connection.RemoteIpAddress!, roleId, membershipId);
            _dbContext.Users.Add(user);
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextSaveException(e);
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            _logger.LogInformation("Signup success");
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        private Claim[] GetClaims(ClaimInfo claimInfo) =>
            [
                new Claim(JwtRegisteredClaimNames.Sub, claimInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, claimInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, claimInfo.UserEmail),
                new Claim(ClaimTypes.Role, claimInfo.RoleName)
            ];
    }
}