using System;
using AutoMapper;
using PersonalMoney.Api.Models;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="dataContext"></param>
        /// <param name="userResolver"></param>
        /// <exception cref="ArgumentException">Invalid user</exception>
        public CategoryService(IMapper mapper,
            AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }
    }
}