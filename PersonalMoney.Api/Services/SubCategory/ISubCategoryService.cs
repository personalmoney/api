using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.SubCategory
{
    /// <summary>
    /// SubCategory service
    /// </summary>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public interface ISubCategoryService : IBaseService<Models.SubCategory, SubCategoryViewModel>
    {
    }
}