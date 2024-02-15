namespace Maladin.Api.Options
{
    public class JwtOptions
    {
        public required string SecureKey { get; set; }

        public required string SecurityAlgorithm { get; set; }

        public TimeSpan AccessTokenExpiration { get; set; }

        public TimeSpan RefreshTokenExpiration { get; set; }

        public int RefreshTokenByteLength { get; set; }

        public string? Issuer { get; set; }

        public string? Audience { get; set; }

        public required string AccessTokenName { get; set; }

        public required string RefreshTokenName { get; set; }
    }
}