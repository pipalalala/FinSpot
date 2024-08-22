using AutoMapper;
using FinSpotAPI.Application.Models.Users;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Models.Users;
using FinSpotAPI.Domain.Repositories.Interfaces;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(
            IMapper mapper,
            IJwtProvider jwtProvider,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
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

            var newUser = _mapper.Map<User>(model);

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

            var accessToken = await _jwtProvider.GenerateTokenAsync();

            return new UserSignInModel { AccessToken = accessToken };
        }
    }
}
