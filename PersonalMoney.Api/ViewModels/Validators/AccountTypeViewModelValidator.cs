using FluentValidation;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// AccountType viewModel validator
    /// </summary>
    /// <seealso cref="AccountTypeViewModel" />
    public class AccountTypeViewModelValidator : NameValidator<AccountType, AccountTypeViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public AccountTypeViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
        : base(dbContext, userResolver, 50)
        {
            RuleFor(c => c.Icon)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}