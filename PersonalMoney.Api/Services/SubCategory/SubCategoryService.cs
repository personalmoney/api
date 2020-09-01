using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.Category;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.SubCategory
{
    /// <summary>
    /// Category service
    /// </summary>
    /// <seealso cref="BaseService{TModel, TViewModel}" />
    /// <seealso cref="ISubCategoryService" />
    public class SubCategoryService : BaseService<Models.SubCategory, SubCategoryViewModel>, ISubCategoryService
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="fireStore">The fire store.</param>
        public SubCategoryService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}