using FinSpotAPI.Infrastructure.Models;

namespace FinSpotAPI.Infrastructure.Services.Interfaces
{
    public interface ICurrentUserProvider
    {
        Task<int> GetCurrentUserIdAsync();

        Task<CurrentUser?> GetCurrentUserAsync();
    }
}
