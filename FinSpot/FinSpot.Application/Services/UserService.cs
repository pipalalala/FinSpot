using FinSpotAPI.Application.Models.UserService;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Models.User;
using FinSpotAPI.Domain.Repositories.Interfaces;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task SignUpAsync(UserSignUpModel model)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            var user = await _userRepository.GetByEmailAsync(model.Email);

            if (user != null)
            {
                throw new ConflictException($"User `{model.Email}` already exists.");
            }

            var newUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                HashedPassword = _passwordHasher.GenerateHashedPassword(model.Password),
                MobileNumber = model.MobileNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                GenderName = model.GenderName,
            };

            await _userRepository.AddAsync(newUser);
        }

        public async Task<UserSignInModel> SignInAsync(string email, string password)
        {
            ArgumentNullException.ThrowIfNull(email, nameof(email));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            var user = await _userRepository.GetByEmailAsync(email)
                ?? throw new NotFoundException($"User `{email}` does not exist.");

            var verificationResult = _passwordHasher.VerifyPassword(password, user.HashedPassword);

            if (!verificationResult)
            {
                throw new AuthenticationException("Incorrect password.");
            }

            // TODO: add generateToken()
            return new UserSignInModel { AccessToken = "AccessToken" };
        }
    }
}
