using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.AccountType
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
        Task<IEnumerable<AccountTypeViewModel>> Get();

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<AccountTypeViewModel> Get(string id);

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<AccountTypeViewModel> Create(AccountTypeViewModel model);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<AccountTypeViewModel> Update(string id, AccountTypeViewModel model);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(string id);
    }
}