using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Tag ViewModel validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class TagViewModelValidator : NameValidator<Models.Tag, TagViewModel>
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagViewModelValidator"/> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        public TagViewModelValidator(IFireStoreService fireStoreService)
            : base(fireStoreService, 50)
        {
        }
    }
}