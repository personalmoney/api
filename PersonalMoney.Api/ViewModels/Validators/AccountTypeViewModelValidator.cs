using FluentValidation;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// AccountType viewModel validator
    /// </summary>
    /// <seealso cref="AccountTypeViewModel" />
    public class AccountTypeViewModelValidator : NameValidator<Models.AccountType, AccountTypeViewModel>
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.AccountTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeViewModelValidator"/> class.
        /// </summary>
        public AccountTypeViewModelValidator(IFireStoreService fireStoreService)
        : base(fireStoreService, 50)
        {
            RuleFor(c => c.Icon)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}