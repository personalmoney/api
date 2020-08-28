using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Services.AccountType;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Account View Model validator
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    public class AccountViewModelValidator : AbstractValidator<AccountViewModel>
    {
        private readonly IFireStoreService fireStoreService;
        private readonly IAccountTypeService accountTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModelValidator" /> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        /// <param name="accountTypeService">The account type service.</param>
        public AccountViewModelValidator(IFireStoreService fireStoreService, IAccountTypeService accountTypeService)
        {
            this.fireStoreService = fireStoreService;
            this.accountTypeService = accountTypeService;
            RuleFor(c => c.Name)
             .NotEmpty()
             .MaximumLength(50);

            RuleFor(c => c.IsActive)
                .NotNull();

            RuleFor(c => c.IncludeInBalance)
             .NotNull();

            RuleFor(c => c.AccountType)
             .NotEmpty()
             .MaximumLength(50);

            RuleFor(c => c)
                .MustAsync(CheckName)
                .OverridePropertyName(c => c.Name)
                .WithMessage(c => $"Record with the name {c.Name} already exists");

            RuleFor(c => c)
                .MustAsync(CheckAccountType)
                .OverridePropertyName(c => c.AccountType)
                .WithMessage(c => "Invalid Account Type");
        }

        private async Task<bool> CheckName(AccountViewModel model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                return await fireStoreService.FindDocumentByName<Models.AccountType>("accounts", model.Name) == null;
            }
            else
            {
                return await fireStoreService.FindDocumentByName<Models.AccountType>("accounts", model.Name, model.Id) == null;
            }
        }

        private async Task<bool> CheckAccountType(AccountViewModel viewModel, CancellationToken cancellationToken)
        {
            return await accountTypeService.Get(viewModel.AccountType) != null;
        }
    }
}