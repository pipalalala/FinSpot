using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Application.Models.Users
{
    public class UserSignUpModel
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public string? MobileNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required Gender Gender { get; set; }

        public string? GenderName { get; set; }
    }
}
