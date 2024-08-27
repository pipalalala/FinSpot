using FinSpotAPI.Domain.Models.Users;

namespace FinSpotAPI.Domain.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task AddAsync(User user);

        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByIdAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
