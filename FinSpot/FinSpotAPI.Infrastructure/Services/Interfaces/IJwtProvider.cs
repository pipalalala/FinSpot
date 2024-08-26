namespace FinSpotAPI.Infrastructure.Services.Interfaces
{
    public interface IJwtProvider
    {
        Task<string> GenerateTokenAsync(int userId);
    }
}
