using AutoMapper;
using FinSpotAPI.Application.Models.Users;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Models.Users;
using FinSpotAPI.Domain.Repositories.Interfaces;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(
            IMapper mapper,
            IJwtProvider jwtProvider,
            IUsersRepository usersRepository,
            IPasswordHasher passwordHasher)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task SignUpAsync(UserSignUpModel model)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            var user = await _usersRepository.GetByEmailAsync(model.Email);

            if (user != null)
            {
                throw new ConflictException($"User `{model.Email}` already exists.");
            }

            var newUser = _mapper.Map<User>(model);

            await _usersRepository.AddAsync(newUser);
        }

        public async Task<UserSignInModel> SignInAsync(string email, string password)
        {
            ArgumentNullException.ThrowIfNull(email, nameof(email));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            var user = await _usersRepository.GetByEmailAsync(email)
                ?? throw new NotFoundException($"User `{email}` does not exist.");

            var verificationResult = _passwordHasher.VerifyPassword(password, user.HashedPassword);

            if (!verificationResult)
            {
                throw new AuthenticationException("Incorrect password.");
            }

            var accessToken = await _jwtProvider.GenerateTokenAsync(user.Id);

            return new UserSignInModel { AccessToken = accessToken };
        }
    }
}
