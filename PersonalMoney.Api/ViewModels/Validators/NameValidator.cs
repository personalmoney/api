using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Name Validator
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <seealso cref="AbstractValidator{TViewModel}" />
    public abstract class NameValidator<TModel, TViewModel> : AbstractValidator<TViewModel>
        where TModel : NameModel
        where TViewModel : NameViewModel
    {
        private readonly AppDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValidator{TModel, TViewModel}" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="maxLength">The maximum length.</param>
        protected NameValidator(AppDbContext dbContext, int maxLength)
        {
            this.dbContext = dbContext;
            RuleFor(c => c.IsDeleted)
                .Must(c => c == false)
                .WithMessage("Delete shouldn't be set to true");

            RuleFor(c => c.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(maxLength)
                .DependentRules(() =>
                {
                    RuleFor(c => c)
                        .MustAsync(CheckName)
                        .OverridePropertyName(c => c.Name)
                        .WithMessage(c => $"Record with the name {c.Name} already exists");
                });
        }

        /// <summary>
        /// Checks the name.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        protected virtual async Task<bool> CheckName(TViewModel model, CancellationToken cancellationToken)
        {
            if (model.Id <= 0)
            {
                return !await dbContext.Set<TModel>().AnyAsync(c => c.Name == model.Name, cancellationToken);
            }
            else
            {
                return !await dbContext.Set<TModel>().Where(c => c.Id != model.Id).AnyAsync(c => c.Name == model.Name, cancellationToken);
            }
        }
    }
}