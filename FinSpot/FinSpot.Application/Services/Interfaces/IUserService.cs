using FinSpotAPI.Application.Models.UserService;

namespace FinSpotAPI.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task SignUpAsync(UserSignUpModel model);
    }
}
