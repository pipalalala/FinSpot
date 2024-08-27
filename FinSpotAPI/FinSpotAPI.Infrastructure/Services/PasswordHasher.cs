using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHashedPassword(string password)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(password, nameof(password));

            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(password, nameof(password));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(hashedPassword, nameof(hashedPassword));

            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
