using System.Collections.Generic;
using MoneyManager.Api.ViewModels;

namespace MoneyManager.Api.Services.AccountType
{
    /// <summary>
    /// AccountType service interface
    /// </summary>
    public interface IAccountTypeService
    {
        /// <summary>
        /// Gets the account types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountTypeViewModel> Get();

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        AccountTypeViewModel Get(int id);
    }
}