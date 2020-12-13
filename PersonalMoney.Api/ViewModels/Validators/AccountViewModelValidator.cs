using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services.AccountType;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Account View Model validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel,TViewModel}" />
    public class AccountViewModelValidator : NameValidator<Account, AccountViewModel>
    {
        private readonly IAccountTypeService accountTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="accountTypeService">The account type service.</param>
        public AccountViewModelValidator(AppDbContext dbContext, IAccountTypeService accountTypeService)
        : base(dbContext, 50)
        {
            this.accountTypeService = accountTypeService;

            RuleFor(c => c.IsActive)
                .NotNull();

            RuleFor(c => c.IncludeInBalance)
             .NotNull();

            RuleFor(c => c.PaymentDate)
                .InclusiveBetween(1, 31)
                .When(c => c.PaymentDate.HasValue);

            RuleFor(c => c.AccountType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(CheckAccountType)
                .WithMessage(c => "Invalid Account Type");
        }

        private async Task<bool> CheckAccountType(int accountType, CancellationToken cancellationToken)
        {
            return await accountTypeService.Get(accountType) != null;
        }
    }
}