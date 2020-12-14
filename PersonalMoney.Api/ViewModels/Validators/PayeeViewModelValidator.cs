using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Payee ViewModel validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class PayeeViewModelValidator : NameValidator<Payee, PayeeViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayeeViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public PayeeViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
            : base(dbContext, userResolver, 50)
        {
        }
    }
}