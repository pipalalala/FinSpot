using FluentValidation;
using FinSpotAPI.Common.Constants;
using FinSpotAPI.Web.Models.V1.Users.Inbound;
using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Web.Validation.V1.Users
{
    public class UserSignUpModelValidator : AbstractValidator<UserSignUpModel>
    {
        public UserSignUpModelValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(ModelValidationConstants.Values.FirstNameMaxLength);

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(ModelValidationConstants.Values.LastNameMaxLength);

            RuleFor(_ => _.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(ModelValidationConstants.Values.EmailMaxLength);

            RuleFor(_ => _.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(ModelValidationConstants.Values.PasswordMaxLength);

            RuleFor(_ => _.MobileNumber)
                .MaximumLength(ModelValidationConstants.Values.MobileNumberMaxLength);

            RuleFor(_ => _.DateOfBirth)
                .Must(_ => _.Date <= DateTime.UtcNow.Date)
                .WithMessage(ModelValidationConstants.ErrorMessages.DateOfBirthMaxValue);
            RuleFor(_ => _.DateOfBirth)
                .Must(_ => _.Date >= ModelValidationConstants.Values.DateOfBirthMinValue)
                .WithMessage(ModelValidationConstants.ErrorMessages.DateOfBirthMinValue);

            RuleFor(_ => _.Gender)
                .IsInEnum();

            RuleFor(_ => _.GenderName)
                .Null()
                .When(_ => _.Gender != Gender.Custom);

            RuleFor(_ => _.GenderName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ModelValidationConstants.Values.GenderNameMaxLength)
                .When(_ => _.Gender == Gender.Custom);
        }
    }
}
