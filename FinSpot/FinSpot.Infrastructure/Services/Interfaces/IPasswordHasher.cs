namespace FinSpotAPI.Infrastructure.Services.Interfaces
{
    public interface IPasswordHasher
    {
        string GenerateHashedPassword(string password);

        public bool VerifyPassword(string password, string hashedPassword);
    }
}
