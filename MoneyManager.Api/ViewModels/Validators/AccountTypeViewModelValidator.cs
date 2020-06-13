using FluentValidation;

namespace MoneyManager.Api.ViewModels.Validators
{
    /// <summary>
    /// AccountType viewModel validator
    /// </summary>
    /// <seealso cref="AccountTypeViewModel" />
    public class AccountTypeViewModelValidator : AbstractValidator<AccountTypeViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeViewModelValidator"/> class.
        /// </summary>
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