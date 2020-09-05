using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <inheritdoc />
        public Task<SubCategoryViewModel> Get(string categoryId, string id)
        {
            SetCollectionName(categoryId);
            return base.Get(id);
        }

        /// <inheritdoc />
        public override Task<SubCategoryViewModel> Create(SubCategoryViewModel model)
        {
            SetCollectionName(model.CategoryId);
            return base.Create(model);
        }

        /// <inheritdoc />
        public override Task<SubCategoryViewModel> Update(string id, SubCategoryViewModel model)
        {
            SetCollectionName(model.CategoryId);
            return base.Update(id, model);
        }

        /// <inheritdoc />
        public Task Delete(string categoryId, string id)
        {
            SetCollectionName(categoryId);
            return base.Delete(id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SubCategoryViewModel>> GetByCategoryId(string categoryId)
        {
            SetCollectionName(categoryId);
            return await base.Get();
        }

        private void SetCollectionName(string categoryId)
        {
            CollectionName = $"{CollectionNames.Categories}/{categoryId}/{CollectionNames.SubCategories}";
        }
    }
}