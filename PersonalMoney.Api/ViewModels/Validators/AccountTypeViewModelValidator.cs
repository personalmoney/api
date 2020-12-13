using FluentValidation;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// AccountType viewModel validator
    /// </summary>
    /// <seealso cref="AccountTypeViewModel" />
    public class AccountTypeViewModelValidator : NameValidator<AccountType, AccountTypeViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeViewModelValidator"/> class.
        /// </summary>
        public AccountTypeViewModelValidator(AppDbContext dbContext)
        : base(dbContext, 50)
        {
            RuleFor(c => c.Icon)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}