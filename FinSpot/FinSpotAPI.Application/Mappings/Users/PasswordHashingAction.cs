using AutoMapper;
using FinSpotAPI.Infrastructure.Services.Interfaces;
using ApplicationModels = FinSpotAPI.Application.Models.Users;
using DomainModels = FinSpotAPI.Domain.Models.Users;

namespace FinSpotAPI.Application.Mappings.Users
{
    public class PasswordHashingAction
        : IMappingAction<ApplicationModels.UserSignUpModel, DomainModels.User>
    {
        private readonly IPasswordHasher _passwordHasher;

        public PasswordHashingAction(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public void Process(
            ApplicationModels.UserSignUpModel source,
            DomainModels.User destination,
            ResolutionContext context)
        {
            destination.HashedPassword = _passwordHasher.GenerateHashedPassword(source.Password);
        }
    }
}
