using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services;

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
        /// <param name="userResolver">The user resolver.</param>
        public CategoryViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
            : base(dbContext, userResolver, 50)
        {
        }
    }
}