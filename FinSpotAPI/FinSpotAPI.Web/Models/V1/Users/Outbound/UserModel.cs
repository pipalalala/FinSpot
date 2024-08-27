using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Web.Models.V1.Users.Outbound
{
    public class UserModel
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string? MobileNumber { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required Gender Gender { get; set; }

        public string? GenderName { get; set; }
    }
}
