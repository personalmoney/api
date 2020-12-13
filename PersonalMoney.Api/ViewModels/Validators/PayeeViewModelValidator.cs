using PersonalMoney.Api.Models;

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
        public PayeeViewModelValidator(AppDbContext dbContext)
            : base(dbContext, 50)
        {
        }
    }
}