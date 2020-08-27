using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// AccountType viewModel validator
    /// </summary>
    /// <seealso cref="AccountTypeViewModel" />
    public class AccountTypeViewModelValidator : AbstractValidator<AccountTypeViewModel>
    {
        private readonly IFireStoreService fireStoreService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeViewModelValidator"/> class.
        /// </summary>
        public AccountTypeViewModelValidator(IFireStoreService fireStoreService)
        {
            this.fireStoreService = fireStoreService;
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.IsActive)
                .NotNull();

            RuleFor(c => c.Icon)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c)
                .MustAsync(CheckName)
                .OverridePropertyName(c => c.Name)
                .WithMessage(c => $"Record with the name {c.Name} already exists");
        }

        private async Task<bool> CheckName(AccountTypeViewModel model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                return await fireStoreService.FindDocumentByName<Models.AccountType>("accountTypes", model.Name) == null;
            }
            else
            {
                return await fireStoreService.FindDocumentByName<Models.AccountType>("accountTypes", model.Name, model.Id) == null;
            }
        }
    }
}