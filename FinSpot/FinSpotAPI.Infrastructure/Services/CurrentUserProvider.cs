using AutoMapper;
using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Repositories.Interfaces;
using FinSpotAPI.Infrastructure.Models;
using FinSpotAPI.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinSpotAPI.Infrastructure.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(
            IMapper mapper,
            IUsersRepository usersRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepository = usersRepository
                ?? throw new ArgumentNullException(nameof(usersRepository));
            _httpContextAccessor = httpContextAccessor
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task<int> GetCurrentUserIdAsync()
        {
            var nameIdentifierClaimValue = _httpContextAccessor
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            return Task.FromResult(nameIdentifierClaimValue == null
                ? throw new AuthenticationException($"No user ID specified.")
                : int.Parse(nameIdentifierClaimValue));
        }

        public async Task<CurrentUser?> GetCurrentUserAsync()
        {
            var userId = await GetCurrentUserIdAsync();

            var currentUser = await _usersRepository.GetByIdAsync(userId);

            return _mapper.Map<CurrentUser>(currentUser);
        }
    }
}
