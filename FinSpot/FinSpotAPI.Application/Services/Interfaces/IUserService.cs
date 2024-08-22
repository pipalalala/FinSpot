using FinSpotAPI.Application.Models.Users;

namespace FinSpotAPI.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task SignUpAsync(UserSignUpModel model);

        Task<UserSignInModel> SignInAsync(string email, string password);
    }
}
