namespace FinSpotAPI.Web.Models.V1.Users.Inbound
{
    public class UserSignInModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
