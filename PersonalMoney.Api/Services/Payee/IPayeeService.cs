using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Payee
{
    /// <summary>
    /// Payee Service
    /// </summary>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public interface IPayeeService : IBaseService<Models.Payee, PayeeViewModel>
    {
    }
}