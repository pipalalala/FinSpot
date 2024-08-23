using FinSpotAPI.Common.Constants;
using FinSpotAPI.Web.Models.V1.Users.Inbound;
using FluentValidation;

namespace FinSpotAPI.Web.Validation.V1.Users
{
    public class UserSignInModelValidator : AbstractValidator<UserSignInModel>
    {
        public UserSignInModelValidator()
        {
            RuleFor(_ => _.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(ModelValidationConstants.Values.EmailMaxLength);

            RuleFor(_ => _.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(ModelValidationConstants.Values.PasswordMaxLength);
        }
    }
}
