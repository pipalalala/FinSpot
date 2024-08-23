using FinSpotAPI.Common.Enumerations;
using FinSpotAPI.Domain.Models.Operations;

namespace FinSpotAPI.Domain.Models.Users
{
    public class User
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string HashedPassword { get; set; }

        public string? MobileNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required Gender Gender { get; set; }

        public string? GenderName { get; set; }

        public ICollection<Operation> Operations { get; set; } = [];
    }
}
