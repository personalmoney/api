using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.SubCategory
{
    /// <summary>
    /// SubCategory service
    /// </summary>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public interface ISubCategoryService : IBaseService<Models.SubCategory, SubCategoryViewModel>
    {
        /// <summary>
        /// Gets the by category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<SubCategoryViewModel>> GetByCategoryId(int categoryId);

        /// <summary>
        /// Gets the specified category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SubCategoryViewModel> Get(int categoryId, int id);

        /// <summary>
        /// Deletes the specified category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(int categoryId, int id);
    }
}