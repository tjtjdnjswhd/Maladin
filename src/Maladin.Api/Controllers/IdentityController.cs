﻿using Maladin.Api.ActionResults;
using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.EFCore.Models;
using Maladin.Services;
using Maladin.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

using System.Diagnostics;
using System.Security.Claims;

namespace Maladin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class IdentityController(MaladinDbContext dbContext, IOptions<JwtOptions> jwtOptions, IJwtService jwtService, IDistributedCache cache, ILogger<IdentityController> logger) : ControllerBase
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
        [Authorize(AuthorizePolicy.OAUTH)]
        public async Task<IActionResult> LoginCallbackAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProviderName = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _logger.LogInformation("Begin login");
            Log.OAuthInfo(_logger, oauthProviderName, nameIdentifier);
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
                    .Select(o => new ClaimInfo(o.UserId, o.User.Name, o.User.Email, o.User.Roles.Select(r => r.Name), _jwtOptions.Issuer, _jwtOptions.Audience))
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
                return new DbContextExceptionResult(e);
            }

            ClaimsIdentity identity = _jwtService.GetClaimsIdentity(claimInfo, await HttpContext.GetDefaultAuthenticationSchemeAsync());

            string accessToken = _jwtService.GetAccessToken(identity, _jwtOptions.SecureKey, _jwtOptions.AccessTokenExpiration, null);
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
                return new DistributedCacheExceptionResult(e);
            }

            try
            {
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            Response.Cookies.Append(_jwtOptions.AccessTokenName, accessToken, cookieOptions);
            Response.Cookies.Append(_jwtOptions.RefreshTokenName, refreshToken, cookieOptions);

            _logger.LogInformation("Login success. UserId: {sub}", claimInfo.UserId);
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpGet("logout")]
        [Authorize(AuthorizePolicy.USER)]
        public async Task<IActionResult> LogoutAsync()
        {
            if (_jwtService.TryGetUserId(User.Claims, out int userId))
            {
                _logger.LogInformation("User logout. UserId: {userId}", userId);
            }
            else
            {
                Debug.Assert(false);
            }
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
                return new DistributedCacheExceptionResult(e);
            }

            if (cachedAccessToken != accessToken)
            {
                _logger.LogInformation("Invalid refresh token");
                return Unauthorized();
            }

            if (!_jwtService.TryGetJwt(cachedAccessToken, out var jwtSecurityToken))
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
                   .Select(u => new ClaimInfo(u.Id, u.Name, u.Email, u.Roles.Select(r => r.Name), _jwtOptions.Issuer, _jwtOptions.Audience))
                   .FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (claimInfo is null)
            {
                _logger.LogInformation("User not exist. UserId: {sub}", userId);
                return NotFound();
            }

            ClaimsIdentity identity = _jwtService.GetClaimsIdentity(claimInfo, await HttpContext.GetDefaultAuthenticationSchemeAsync());

            string newAccessToken = _jwtService.GetAccessToken(identity, _jwtOptions.SecureKey, _jwtOptions.AccessTokenExpiration, null);
            string newRefreshToken = _jwtService.GetRefreshToken(_jwtOptions.RefreshTokenByteLength);

            try
            {
                await _cache.RemoveAsync(refreshToken, cancellationToken);
                await _cache.SetStringAsync(refreshToken, accessToken, cancellationToken);
            }
            catch (Exception e)
            {
                return new DistributedCacheExceptionResult(e);
            }

            return Ok();
        }

        [HttpGet("signup")]
        [Authorize(AuthorizePolicy.OAUTH)]
        public async Task<IActionResult> SignupCallbackAsync([FromQuery] string? returnUrl, CancellationToken cancellationToken)
        {
            string? oauthProviderName = User.Identity?.AuthenticationType;
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string? email = User.FindFirstValue(ClaimTypes.Email);

            _logger.LogInformation("Begin signup");
            Log.OAuthInfo(_logger, oauthProviderName, nameIdentifier);
            AuthenticationProperties? authenticationProperties = (await HttpContext.AuthenticateAsync(oauthProviderName)).Properties;
            if (oauthProviderName is null || nameIdentifier is null || email is null || authenticationProperties is null || !authenticationProperties.Items.TryGetValue(SIGNUP_USER_NAME, out string? userName) || userName is null)
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
                return new DbContextExceptionResult(e);
            }

            if (oauthProvider is null)
            {
                Log.OAuthProviderDBNotRegisted(_logger, oauthProviderName);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProviderName))
            {
                Log.OAuthProviderSchemeNotRegisted(_logger, oauthProviderName);
                return StatusCode(StatusCodes.Status500InternalServerError);
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

                Role? role = await _dbContext.Roles.OrderBy(r => r.Priority).FirstOrDefaultAsync(cancellationToken);
                int membershipId = await _dbContext.Memberships.OrderBy(r => r.Level).Select(r => r.Level).FirstOrDefaultAsync(cancellationToken);
                if (role is null || membershipId == default)
                {
                    _logger.LogError("Membership or Roles in DB not exist");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                User user = new(userName, email, HttpContext.Connection.RemoteIpAddress!, membershipId);
                user.Roles.Add(role);

                OAuthId oAuthId = new(nameIdentifier, oauthProvider, user);
                _dbContext.OAuthIds.Add(oAuthId);

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            _logger.LogInformation("Signup success");
            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpGet("add")]
        [Authorize(AuthorizePolicy.OAUTH)]
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
            Log.OAuthInfo(_logger, oauthProviderName, nameIdentifier);
            if (oauthProviderName is null || nameIdentifier is null)
            {
                return Unauthorized();
            }

            if (!await HttpContext.IsAuthenticationSchemeExist(oauthProviderName))
            {
                Log.OAuthProviderSchemeNotRegisted(_logger, oauthProviderName);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            int oauthProviderId;
            try
            {
                oauthProviderId = await _dbContext.OAuthProviders.Where(o => o.Name == oauthProviderName).Select(o => o.Id).FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (oauthProviderId == default)
            {
                Log.OAuthProviderDBNotRegisted(_logger, oauthProviderName);
                return BadRequest();
            }

            if (!_jwtService.TryGetUserId(defaultAuthenticationResult.Principal.Claims, out int userId))
            {
                Debug.Assert(false);
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
                return new DbContextExceptionResult(e);
            }

            return returnUrl is null ? Ok() : Redirect(returnUrl);
        }

        [HttpPost("remove")]
        [Authorize(AuthorizePolicy.USER)]
        public async Task<IActionResult> RemoveAsync([FromQuery] string oauthProvider, CancellationToken cancellationToken)
        {
            if (!_jwtService.TryGetUserId(User.Claims, out int userId))
            {
                Debug.Assert(false);
                return BadRequest();
            }

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
                    //TODO: return with user can not login with oauth provider message
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }
        }

        private static partial class Log
        {
            [LoggerMessage(Level = LogLevel.Information, Message = "OAuthProviderName: {oauthProviderName}, NameIdentifier: {nameIdentifier}")]
            public static partial void OAuthInfo(ILogger logger, string? oauthProviderName, string? nameIdentifier);

            [LoggerMessage(LogLevel.Warning, "OAuth provider not registed from DB. provider name: {oauthProviderName}")]
            public static partial void OAuthProviderDBNotRegisted(ILogger logger, string oauthProviderName);

            [LoggerMessage(LogLevel.Warning, "OAuth authentication scheme not registed. provider name: {oauthProviderName}")]
            public static partial void OAuthProviderSchemeNotRegisted(ILogger logger, string oauthProviderName);
        }
    }
}