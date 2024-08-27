using FinSpotAPI.Common.Models.Options;
using FinSpotAPI.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinSpotAPI.Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly ISecretsManager _secretsManager;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly AuthenticationOptions _authenticationOptions;

        public JwtProvider(
            ISecretsManager secretsManager,
            ICurrentUserProvider currentUserProvider,
            IOptions<AuthenticationOptions> authenticationOptions)
        {
            _secretsManager = secretsManager
                ?? throw new ArgumentNullException(nameof(secretsManager));
            _currentUserProvider = currentUserProvider
                ?? throw new ArgumentNullException(nameof(currentUserProvider));
            _authenticationOptions = authenticationOptions?.Value
                ?? throw new ArgumentNullException(nameof(authenticationOptions));
        }

        public async Task<string> GenerateTokenAsync(int userId)
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
                claims: GetClaims(userId.ToString()),
                expires: DateTime.UtcNow.AddMinutes(_authenticationOptions.TokenLifetimeMinutes));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }

        private IEnumerable<Claim> GetClaims(string userId) =>
            [
                new Claim(ClaimTypes.NameIdentifier, userId),
            ];
    }
}
