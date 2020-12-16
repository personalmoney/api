using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services;
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
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly AppDbContext DbContext;

        /// <summary>
        /// The user resolver
        /// </summary>
        protected readonly UserResolverService UserResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValidator{TModel, TViewModel}" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver service</param>
        /// <param name="maxLength">The maximum length.</param>
        protected NameValidator(AppDbContext dbContext, UserResolverService userResolver, int maxLength)
        {
            DbContext = dbContext;
            UserResolver = userResolver;

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
            var query = DbContext
                .Set<TModel>()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == UserResolver.GetUserId())
                .Where(c => c.Name == model.Name);

            if (model.Id <= 0)
            {
                return !await query.AnyAsync(cancellationToken);
            }

            return !await query
                .Where(c => c.Id != model.Id)
                .AnyAsync(c => c.Name == model.Name, cancellationToken);
        }
    }
}