using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Account
{
    /// <summary>
    /// The Account Management service
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccountViewModel>> Get();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<AccountViewModel> Get(string id);

        /// <summary>
        /// Creates the Account.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<AccountViewModel> Create(AccountViewModel model);

        /// <summary>
        /// Updates the Account with the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<AccountViewModel> Update(string id, AccountViewModel model);

        /// <summary>
        /// Deletes the Account with the given id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(string id);
    }
}