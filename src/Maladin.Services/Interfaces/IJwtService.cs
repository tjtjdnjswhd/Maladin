using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Maladin.Services.Interfaces
{
    public interface IJwtService
    {
        string GetAccessToken(ClaimsIdentity identity, string secureKey, TimeSpan? tokenExpiration, DateTime? notBefore);
        string GetRefreshToken(int byteLength);
        bool TryGetJwt(string accessToken, [NotNullWhen(true)] out JwtSecurityToken? result);
        ClaimsIdentity GetClaimsIdentity(ClaimInfo claimInfo, string? authenticationType);
        bool TryGetUserId(IEnumerable<Claim> claims, out int userId);
        bool TryGetName(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? name);
        bool TryGetEmail(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? email);
        bool TryGetAudience(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? audience);
        bool TryGetIssuer(IEnumerable<Claim> claims, [NotNullWhen(true)] out string? issuer);
        bool TryGetRoles(IEnumerable<Claim> claims, [NotNullWhen(true)] out string[]? roles);
    }
}