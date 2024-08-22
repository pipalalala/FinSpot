using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Domain.Models.User
{
    public class User
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string HashedPassword { get; set; }

        public string? MobileNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required Gender Gender { get; set; }

        public string? GenderName { get; set; }
    }
}
