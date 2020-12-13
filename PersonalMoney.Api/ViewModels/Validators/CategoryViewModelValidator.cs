using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Category ViewModel
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class CategoryViewModelValidator : NameValidator<Category, CategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CategoryViewModelValidator(AppDbContext dbContext)
            : base(dbContext, 50)
        {
        }
    }
}