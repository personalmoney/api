using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Category
{
    /// <summary>
    /// Category service
    /// </summary>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public interface ICategoryService : IBaseService<Models.Category, CategoryViewModel>
    {
    }
}