using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Account View Model validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel,TViewModel}" />
    public class AccountViewModelValidator : NameValidator<Account, AccountViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public AccountViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
        : base(dbContext, userResolver, 50)
        {
            RuleFor(c => c.IsActive)
                .NotNull();

            RuleFor(c => c.IncludeInBalance)
             .NotNull();

            RuleFor(c => c.PaymentDate)
                .InclusiveBetween(1, 31)
                .When(c => c.PaymentDate.HasValue);

            RuleFor(c => c.AccountTypeId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(CheckAccountType)
                .WithMessage(c => "Invalid Account Type");
        }

        private async Task<bool> CheckAccountType(int accountType, CancellationToken cancellationToken)
        {
            return await DbContext.AccountTypes
                .Where(c => !c.IsDeleted)
                .AsNoTracking()
                .Where(c => c.User.UserId == UserResolver.GetUserId())
                .Where(c => c.Id == accountType)
                .AnyAsync(cancellationToken);
        }
    }
}