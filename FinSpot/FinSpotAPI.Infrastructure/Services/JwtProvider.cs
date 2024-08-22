using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FinSpotAPI.Common.Models.Options;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly ISecretsManager _secretsManager;
        private readonly AuthenticationOptions _authenticationOptions;

        public JwtProvider(
            ISecretsManager secretsManager,
            IOptions<AuthenticationOptions> authenticationOptions)
        {
            _authenticationOptions = authenticationOptions?.Value
                ?? throw new ArgumentNullException(nameof(authenticationOptions));
            _secretsManager = secretsManager ?? throw new ArgumentNullException(nameof(secretsManager));
        }

        public async Task<string> GenerateTokenAsync()
        {
            var issuerSigningKey = await _secretsManager.GetSecretAsync(_authenticationOptions.IssuerSigningKeySecretName);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey!));
            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authenticationOptions.Issuer,
                audience: _authenticationOptions.Audience,
                signingCredentials: signingCredentials,
                claims: GetClaims(),
                expires: DateTime.UtcNow.AddMinutes(_authenticationOptions.TokenLifetimeMinutes));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }

        private IEnumerable<Claim> GetClaims()
        {
            return [];
        }
    }
}
