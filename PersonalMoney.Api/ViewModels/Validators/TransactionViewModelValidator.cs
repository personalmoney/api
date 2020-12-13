using FluentValidation;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Transaction view model validator
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    public class TransactionViewModelValidator : AbstractValidator<TransactionViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionViewModelValidator"/> class.
        /// </summary>
        public TransactionViewModelValidator()
        {
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.Amount).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Type).NotEmpty().IsInEnum();
            RuleFor(c => c.Account).NotEmpty();
            RuleFor(c => c.ToAccount).NotEmpty().When(c => c.Type == Helpers.TransactionType.Transfer);
            RuleFor(c => c.SubCategory).NotEmpty().When(c => c.Type != Helpers.TransactionType.Transfer);
            RuleFor(c => c.Payee).NotEmpty().When(c => c.Type != Helpers.TransactionType.Transfer);
            RuleFor(c => c.Notes).MaximumLength(250);
            RuleFor(c => c.Tags).Must(d => d.Count <= 5).WithMessage("Maximum 5 tags allowed");
        }
    }
}