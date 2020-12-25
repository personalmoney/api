using FluentValidation;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// User model validator
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class.
        /// </summary>
        public UserValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.EmailAddress).NotEmpty();
        }
    }
}