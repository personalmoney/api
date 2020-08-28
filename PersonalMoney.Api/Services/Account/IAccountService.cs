using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Account
{
    /// <summary>
    /// The Account Management service
    /// </summary>
    public interface IAccountService : IBaseService<Models.Account, AccountViewModel>
    {
    }
}