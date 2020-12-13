using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services.Category;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// SubCategory ViewModel
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class SubCategoryViewModelValidator : NameValidator<SubCategory, SubCategoryViewModel>
    {
        private readonly AppDbContext dbContext;
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="categoryService">The category service.</param>
        public SubCategoryViewModelValidator(AppDbContext dbContext, ICategoryService categoryService)
            : base(dbContext, 50)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;

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
            if (model.Id <= 0)
            {
                return !await dbContext.SubCategories
                    .Where(c => c.CategoryId == model.CategoryId)
                    .AnyAsync(c => c.Name == model.Name, cancellationToken);
            }
            else
            {
                return !await dbContext.SubCategories
                    .Where(c => c.CategoryId == model.CategoryId)
                    .Where(c => c.Id != model.Id)
                    .AnyAsync(c => c.Name == model.Name, cancellationToken);
            }
        }

        private async Task<bool> CheckCategory(int categoryId, CancellationToken cancellationToken)
        {
            return await categoryService.Get(categoryId) != null;
        }
    }
}