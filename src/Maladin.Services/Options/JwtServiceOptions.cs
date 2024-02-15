﻿using Microsoft.IdentityModel.Tokens;

namespace Maladin.Services.Options
{
    public class JwtServiceOptions
    {
        public Func<string, SecurityKey>? GenerateSecurityKey { get; set; }

        /// <summary>
        /// see <see cref="Microsoft.IdentityModel.Tokens.SecurityAlgorithms"/>
        /// </summary>
        public string? SecurityAlgorithm { get; set; }
    }
}