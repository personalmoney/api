using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Services.Category;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="dataContext"></param>
        /// <param name="userResolver"></param>
        /// <exception cref="ArgumentException">Invalid user</exception>
        public SubCategoryService(IMapper mapper,
            AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }

        /// <inheritdoc />
        public Task<IEnumerable<SubCategoryViewModel>> GetByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<SubCategoryViewModel> Get(string categoryId, string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task Delete(string categoryId, string id)
        {
            throw new NotImplementedException();
        }
    }
}