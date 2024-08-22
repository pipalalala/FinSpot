using FinSpotAPI.Domain.Models.Users;
using FinSpotAPI.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinSpotAPI.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinSpotContext _context;

        public UserRepository(FinSpotContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(email, nameof(email));

            return _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Email == email);
        }
    }
}
