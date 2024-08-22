using FinSpotAPI.Domain.Models.User;
using FinSpotAPI.Domain.Repositories.Interfaces;

namespace FinSpotAPI.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            return Task.CompletedTask;
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(email, nameof(email));

            return Task.FromResult<User?>(null);
        }
    }
}
