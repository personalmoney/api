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
    /// SubCategory ViewModel
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class SubCategoryViewModelValidator : NameValidator<SubCategory, SubCategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public SubCategoryViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
            : base(dbContext, userResolver, 50)
        {
            RuleFor(c => c.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(CheckCategory)
                .WithMessage(c => "Invalid Parent category");
        }

        /// <inheritdoc />
        protected override async Task<bool> CheckName(SubCategoryViewModel model, CancellationToken cancellationToken)
        {
            if (model.CategoryId <= 0)
            {
                return false;
            }

            var query = DbContext.SubCategories
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.CategoryId == model.CategoryId)
                .Where(c => c.Name == model.Name)
                .Where(c => c.UserId == UserResolver.GetUserId());

            if (model.Id <= 0)
            {
                return !await query.AnyAsync(cancellationToken);
            }
            else
            {
                return !await query
                    .Where(c => c.Id != model.Id)
                    .AnyAsync(cancellationToken);
            }
        }

        private async Task<bool> CheckCategory(int categoryId, CancellationToken cancellationToken)
        {
            return await DbContext.Categories
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.Id == categoryId)
                .Where(c => c.UserId == UserResolver.GetUserId())
                .AnyAsync(cancellationToken);
        }
    }
}