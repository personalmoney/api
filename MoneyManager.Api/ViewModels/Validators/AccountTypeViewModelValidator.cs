using FluentValidation;

namespace MoneyManager.Api.ViewModels.Validators
{
    public class AccountTypeViewModelValidator : AbstractValidator<AccountTypeViewModel>
    {
        public AccountTypeViewModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.IsActive)
                .NotNull();
        }
    }
}