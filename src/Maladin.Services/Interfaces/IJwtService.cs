using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Maladin.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(ClaimsIdentity identity, string secureKey, TimeSpan? tokenExpiration, DateTime? notBefore);
        string GetRefreshToken(int byteLength);
        bool TryGetToken(string accessToken, [NotNullWhen(true)] out JwtSecurityToken? result);
    }
}