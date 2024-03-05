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
        private static readonly JwtSecurityTokenHandler TokenHandler = new();

        private readonly JwtServiceOptions _options = options.Value;

        public string GenerateToken(ClaimsIdentity identity, string secureKey, TimeSpan? tokenExpiration, DateTime? notBefore)
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

        public bool TryGetToken(string accessToken, [NotNullWhen(true)] out JwtSecurityToken? result)
        {
            if (TokenHandler.CanReadToken(accessToken))
            {
                result = TokenHandler.ReadJwtToken(accessToken);
                return true;
            }

            result = null;
            return false;
        }
    }
}