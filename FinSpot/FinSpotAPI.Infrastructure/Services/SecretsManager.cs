using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Infrastructure.Services
{
    public class SecretsManager : ISecretsManager
    {
        public Task<string?> GetSecretAsync(string secretName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(secretName, nameof(secretName));

            // TODO: add call to real secrets manager
            string? secretValue = Guid.NewGuid().ToString();

            if (secretName == "Issuer")
            {
                secretValue = "Issuer";
            }
            if (secretName == "Audience")
            {
                secretValue = "Audience";
            }
            if (secretName == "IssuerSigningKey")
            {
                secretValue = "IssuerSigningKey";
            }
            if (secretName == "TokenLifetime")
            {
                secretValue = "10";
            }

            return Task.FromResult<string?>(secretValue);
        }
    }
}
