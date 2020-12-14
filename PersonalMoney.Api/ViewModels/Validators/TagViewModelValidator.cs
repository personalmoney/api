using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services;

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
        /// <param name="userResolver">The user resolver.</param>
        public TagViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
            : base(dbContext, userResolver, 50)
        {
        }
    }
}