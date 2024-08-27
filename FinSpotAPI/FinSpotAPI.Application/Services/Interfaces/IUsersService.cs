using FinSpotAPI.Application.Models.Users;

namespace FinSpotAPI.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task SignUpAsync(UserSignUpModel model);

        Task<UserSignInModel> SignInAsync(string email, string password);

        Task DeleteAccountAsync();

        Task<UserModel> GetUserInfoAsync();
    }
}
