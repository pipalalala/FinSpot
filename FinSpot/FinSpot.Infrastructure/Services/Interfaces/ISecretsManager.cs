namespace FinSpotAPI.Infrastructure.Services.Interfaces
{
    public interface ISecretsManager
    {
        Task<string?> GetSecretAsync(string secretName);
    }
}
