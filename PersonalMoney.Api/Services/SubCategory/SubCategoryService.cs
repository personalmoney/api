using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;
        private readonly AppDbContext dataContext;
        private readonly UserResolverService userResolver;

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
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.userResolver = userResolver;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SubCategoryViewModel>> GetByCategoryId(int categoryId)
        {
            var models = await dataContext.SubCategories
                .Where(c => !c.IsDeleted)
                .Where(c => c.CategoryId == categoryId)
                .Where(c => c.UserId == userResolver.GetUserId())
                .ToListAsync();

            var viewModels = mapper.Map<IEnumerable<SubCategoryViewModel>>(models);
            return viewModels;
        }

        /// <inheritdoc />
        public Task<SubCategoryViewModel> Get(int categoryId, int id)
        {
            return base.Get(id);
        }

        /// <inheritdoc />
        public Task Delete(int categoryId, int id)
        {
            return base.Delete(id);
        }
    }
}