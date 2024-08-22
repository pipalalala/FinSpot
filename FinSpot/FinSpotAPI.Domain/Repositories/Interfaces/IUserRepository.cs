using FinSpotAPI.Domain.Models.Users;

namespace FinSpotAPI.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User?> GetByEmailAsync(string email);
    }
}
