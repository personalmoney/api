using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Tag ViewModel validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class TagViewModelValidator : NameValidator<Tag, TagViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public TagViewModelValidator(AppDbContext dbContext)
            : base(dbContext, 50)
        {
        }
    }
}