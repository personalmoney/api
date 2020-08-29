using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Category
{
    /// <summary>
    /// Category service
    /// </summary>
    /// <seealso cref="BaseService{TModel, TViewModel}" />
    /// <seealso cref="ICategoryService" />
    public class CategoryService : BaseService<Models.Category, CategoryViewModel>, ICategoryService
    {
        /// <inheritdoc />
        public override string CollectionName { get; } = CollectionNames.Categories;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="fireStore">The fire store.</param>
        public CategoryService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}