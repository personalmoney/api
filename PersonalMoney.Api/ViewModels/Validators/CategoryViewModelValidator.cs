using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Category ViewModel
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class CategoryViewModelValidator : NameValidator<Models.Category, CategoryViewModel>
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Categories;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryViewModelValidator"/> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        public CategoryViewModelValidator(IFireStoreService fireStoreService)
            : base(fireStoreService, 50)
        {
        }
    }
}