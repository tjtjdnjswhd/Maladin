using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.EFCore.Models;
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
        private const string SIGNUP_USER_NAME = "userName";

        private readonly MaladinDbContext _dbContext = dbContext;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IDistributedCache _cache = cache;
        private readonly ILogger<IdentityController> _logger = logger;

        [HttpPost("challenge")]
        public IActionResult OAuthChallenge([FromBody] ChallengeInfo challengeInfo)
        {
            AuthenticationProperties authenticationProperties = new()
            {
                RedirectUri = Url.ActionLink($"{challengeInfo.ChallengeKind}Callback", "Identity", new { challengeInfo.ReturnUrl }),
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
            };

            if (challengeInfo.UserName is not null)
            {
                authenticationProperties.Items.Add(SIGNUP_USER_NAME, challengeInfo.UserName);
            }
            return Challenge(authenticationProperties, challengeInfo.OAuthProviderName);
        }

        [HttpGet("login")]
        [Authorize(AuthorizePolicyConstants.OAUTH)]
        public async Task<IActionResult> LoginCallbackAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProviderName = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _logger.LogInformation("Begin login");
            _logger.LogOAuthInfo(oauthProviderName, nameIdentifier);
            if (oauthProviderName is null || nameIdentifier is null)
            {
                return Unauthorized();
            }

            ClaimInfo? claimInfo;
            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                claimInfo = await _dbContext.OAuthIds
                    .Where(o => o.Provider.Name == oauthProviderName && o.NameIdentifier == nameIdentifier)
                    .Select(o => new ClaimInfo() { UserId = o.UserId, UserName = o.User.Name, UserEmail = o.User.Email, RoleName = o.User.Role.Name })
                    .FirstOrDefaultAsync(cancellationToken);

                if (claimInfo is null)
                {
                    return NotFound();
                }

                int updatedRowCount = await _dbContext.Users
                    .Where(u => u.Id == claimInfo.UserId)
                    .ExecuteUpdateAsync(set =>
                        set.SetProperty(u => u.LastLoginIp, HttpContext.Connection.RemoteIpAddress)
                        .SetProperty(u => u.LastLoginDate, DateTimeOffset.UtcNow),
                        cancellationToken);

                if (updatedRowCount == 0)
                {
                    _logger.LogInformation("UserId {sub} not exist", claimInfo.UserId);
                    return Conflict();
                }
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
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
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogDistributedCacheException(e);
                return this.InternalServerError();
            }

            try
            {
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            Response.Cookies.Append(_jwtOptions.AccessTokenName, accessToken, cookieOptions);
            Response.Cookies.Append(_jwtOptions.RefreshTokenName, refreshToken, cookieOptions);

            _logger.LogInformation("Login success. UserId: {sub}", claimInfo.UserId);
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpGet("logout")]
        [Authorize(AuthorizePolicyConstants.USER)]
        public async Task<IActionResult> LogoutAsync()
        {
            _logger.LogInformation("User logout. UserId: {sub}", User.FindFirstValue(JwtRegisteredClaimNames.Sub));
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
                Response.Headers.Append("Refresh-Token-Expired", StringValues.Empty);
                return BadRequest();
            }

            string? cachedAccessToken;

            try
            {
                cachedAccessToken = await _cache.GetStringAsync(refreshToken, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDistributedCacheException(e);
                return this.InternalServerError();
            }

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
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            if (claimInfo is null)
            {
                _logger.LogInformation("User not exist. UserId: {sub}", userId);
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
                return this.InternalServerError();
            }

            return Ok();
        }

        [HttpGet("signup")]
        [Authorize(AuthorizePolicyConstants.OAUTH)]
        public async Task<IActionResult> SignupCallbackAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProviderName = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string? email = User.FindFirstValue(ClaimTypes.Email);

            _logger.LogInformation("Begin signup");
            _logger.LogOAuthInfo(oauthProviderName, nameIdentifier);
            AuthenticationProperties? authenticationProperties = (await HttpContext.AuthenticateAsync(oauthProviderName)).Properties;
            if (oauthProviderName is null || nameIdentifier is null || email is null || authenticationProperties is null || !authenticationProperties.Items.TryGetValue(SIGNUP_USER_NAME, out string? userName))
            {
                _logger.LogInformation("Invalid signup info");
                return Unauthorized();
            }

            OAuthProvider? oauthProvider;
            try
            {
                oauthProvider = await _dbContext.OAuthProviders.FirstOrDefaultAsync(o => o.Name == oauthProviderName, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            if (oauthProvider is null)
            {
                LogOAuthProviderDBNotRegisted(oauthProviderName);
                return this.InternalServerError();
            }

            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProviderName))
            {
                LogOAuthProviderSchemeNotRegiested(oauthProviderName);
                return this.InternalServerError();
            }

            try
            {
                bool isNameIdentifierDuplicate = await _dbContext.OAuthIds.AnyAsync(o => o.Provider.Name == oauthProviderName && o.NameIdentifier == nameIdentifier, cancellationToken);
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
                    _logger.LogError("Membership or Role in DB not exist");
                    return this.InternalServerError();
                }

                User user = new(userName!, email, HttpContext.Connection.RemoteIpAddress!, roleId, membershipId);
                OAuthId oAuthId = new(nameIdentifier, oauthProvider, user);
                _dbContext.OAuthIds.Add(oAuthId);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            _logger.LogInformation("Signup success");
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpGet("add")]
        [Authorize(AuthorizePolicyConstants.OAUTH)]
        public async Task<IActionResult> AddCallbackAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            AuthenticateResult defaultAuthenticationResult = await HttpContext.AuthenticateAsync();
            if (!defaultAuthenticationResult.Succeeded)
            {
                return Unauthorized();
            }

            string? oauthProviderName = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _logger.LogInformation("Begin login");
            _logger.LogOAuthInfo(oauthProviderName, nameIdentifier);
            if (oauthProviderName is null || nameIdentifier is null)
            {
                return Unauthorized();
            }

            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProviderName))
            {
                LogOAuthProviderSchemeNotRegiested(oauthProviderName);
                return this.InternalServerError();
            }

            int oauthProviderId;
            try
            {
                oauthProviderId = await _dbContext.OAuthProviders.Where(o => o.Name == oauthProviderName).Select(o => o.Id).FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            if (oauthProviderId == default)
            {
                LogOAuthProviderDBNotRegisted(oauthProviderName);
                return BadRequest();
            }

            string? sub = defaultAuthenticationResult.Principal.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (!int.TryParse(sub, out var userId))
            {
                _logger.LogWarning("User must be integer. value: {sub}", sub);
                return BadRequest();
            }

            OAuthId oAuthId = new(nameIdentifier, oauthProviderId, userId);
            try
            {
                _dbContext.OAuthIds.Add(oAuthId);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }

            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpPost("remove")]
        [Authorize(AuthorizePolicyConstants.USER)]
        public async Task<IActionResult> RemoveAsync([FromQuery] string oauthProvider, CancellationToken cancellationToken)
        {
            int userId = int.Parse(User.FindFirstValue(JwtRegisteredClaimNames.Sub)!);
            try
            {
                int oauthIdsCount = await _dbContext.OAuthIds.Where(o => o.UserId == userId).CountAsync(cancellationToken);
                if (oauthIdsCount < 2)
                {
                    //TODO: return with at least one oauthId required message
                    return BadRequest();
                }

                int deletedRowCount = await _dbContext.OAuthIds.Where(o => o.UserId == userId && o.Provider.Name == oauthProvider).ExecuteDeleteAsync(cancellationToken);
                if (deletedRowCount == 0)
                {
                    //TODO: return with 
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogDbContextException(e);
                return this.InternalServerError();
            }
        }

        private void LogOAuthProviderDBNotRegisted(string oauthProviderName)
        {
            _logger.LogWarning("OAuth provider not registed from DB. provider name: {oauthProviderName}", oauthProviderName);
        }

        private void LogOAuthProviderSchemeNotRegiested(string oauthProviderName)
        {
            _logger.LogWarning("OAuth authentication scheme not registed. provider name: {oauthProviderName}", oauthProviderName);
        }

        private Claim[] GetClaims(ClaimInfo claimInfo) =>
            [
                new Claim(JwtRegisteredClaimNames.Sub, claimInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, claimInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, claimInfo.UserEmail),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtOptions.Audience),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Issuer),
                new Claim(ClaimTypes.Role, claimInfo.RoleName)
            ];
    }
}