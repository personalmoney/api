using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Tag
{
    /// <summary>
    /// Tag Service
    /// </summary>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public interface ITagService : IBaseService<Models.Tag, TagViewModel>
    {
    }
}