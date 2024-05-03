using Maladin.Services.Interfaces;
using Maladin.Services.Options;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Maladin.Services
{
    public class JwtService(IOptions<JwtServiceOptions> options) : IJwtService
    {
        public const string SubType = JwtRegisteredClaimNames.Sub;
        public const string NameType = JwtRegisteredClaimNames.Name;
        public const string EmailType = JwtRegisteredClaimNames.Email;
        public const string AudienceType = JwtRegisteredClaimNames.Aud;
        public const string IssuerType = JwtRegisteredClaimNames.Iss;
        public const string RoleType = ClaimTypes.Role;

        private static readonly JwtSecurityTokenHandler TokenHandler = new();

        private readonly JwtServiceOptions _options = options.Value;

        public string GetAccessToken(ClaimsIdentity identity, string secureKey, TimeSpan? tokenExpiration, DateTime? notBefore)
        {
            SecurityKey key = _options.GenerateSecurityKey(secureKey);
            SigningCredentials credentials = new(key, _options.SecurityAlgorithm);

            JwtSecurityToken token = TokenHandler.CreateJwtSecurityToken(
                subject: identity,
                notBefore: notBefore,
                expires: tokenExpiration is null ? null : DateTime.UtcNow.Add(tokenExpiration.Value),
                signingCredentials: credentials
            );

            string accessToken = TokenHandler.WriteToken(token);
            return accessToken;
        }

        public string GetRefreshToken(int byteLength)
        {
            byte[] randomNumber = RandomNumberGenerator.GetBytes(byteLength);
            return Convert.ToBase64String(randomNumber);
        }

        public bool TryGetJwt(string accessToken, [NotNullWhen(true)] out JwtSecurityToken? result)
        {
            if (TokenHandler.CanReadToken(accessToken))
            {
                result = TokenHandler.ReadJwtToken(accessToken);
                return true;
            }

            result = null;
            return false;
        }

        public ClaimsIdentity GetClaimsIdentity(ClaimInfo claimInfo, string? authenticationType)
        {
            Claim[] claims =
                [
                    new Claim(SubType, claimInfo.UserId.ToString()),
                    new Claim(NameType, claimInfo.UserName),
                    new Claim(EmailType, claimInfo.UserEmail),
                    new Claim(AudienceType, claimInfo.Audience),
                    new Claim(IssuerType, claimInfo.Issuer),
                    new Claim(RoleType, string.Join(',', claimInfo.Roles))
                ];

            return new ClaimsIdentity(claims, authenticationType, NameType, RoleType);
        }

        public bool TryGetUserId(IEnumerable<Claim> claims, out int userId)
        {
            Claim? sub = claims.FirstOrDefault(c => c.Type == SubType);
            return int.TryParse(sub?.Value, out userId);
        }

        public bool TryGetName(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? name)
        {
            Claim? claim = claims.FirstOrDefault(c => c.Type == NameType);
            return (name = claim?.Value) is not null;
        }

        public bool TryGetEmail(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? email)
        {
            Claim? claim = claims.FirstOrDefault(c => c.Type == EmailType);
            return (email = claim?.Value) is not null;
        }

        public bool TryGetAudience(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? audience)
        {
            Claim? claim = claims.FirstOrDefault(c => c.Type == AudienceType);
            return (audience = claim?.Value) is not null;
        }

        public bool TryGetIssuer(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? issuer)
        {
            Claim? claim = claims.FirstOrDefault(c => c.Type == IssuerType);
            return (issuer = claim?.Value) is not null;
        }

        public bool TryGetRoles(IEnumerable<Claim> claims, [NotNullWhen(true)] out string[]? roles)
        {
            Claim? claim = claims.FirstOrDefault(c => c.Type == RoleType);
            return (roles = claim?.Value.Split(',', options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) is not null;
        }
    }
}