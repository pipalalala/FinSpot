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

            if (secretName == "IssuerSigningKey")
            {
                secretValue = "IssuerSigningKeyIssuerSigningKeyIssuerSigningKeyIssuerSigningKey";
            }
            if (secretName == "FinSpotPostgresConnectionString")
            {
                secretValue = "Server=localhost;Port=5432;User Id=FinSpot;Password=123456;Database=FinSpot;";
            }

            return Task.FromResult<string?>(secretValue);
        }
    }
}
