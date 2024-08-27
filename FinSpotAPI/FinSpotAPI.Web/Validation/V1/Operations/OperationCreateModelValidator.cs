using FinSpotAPI.Common.Constants;
using FinSpotAPI.Web.Models.V1.Operations.Inbound;
using FluentValidation;

namespace FinSpotAPI.Web.Validation.V1.Operations
{
    public class OperationCreateModelValidator : AbstractValidator<OperationCreateModel>
    {
        public OperationCreateModelValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(ModelValidationConstants.Values.Title);

            RuleFor(_ => _.Type)
                .IsInEnum();

            RuleFor(_ => _.Currency)
                .IsInEnum();

            RuleFor(_ => _.ExpenseCategory)
                .IsInEnum();

            RuleFor(_ => _.Details)
                .MaximumLength(ModelValidationConstants.Values.Details)
                .When(_ => !string.IsNullOrWhiteSpace(_.Details));
        }
    }
}
