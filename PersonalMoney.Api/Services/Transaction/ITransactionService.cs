using System.Threading.Tasks;
using PersonalMoney.Api.ViewModels;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.Services.Transaction
{
    /// <summary>
    /// Transaction service
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Creates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task<TransactionViewModel> Create(TransactionViewModel value);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<TransactionViewModel> Update(int id, TransactionViewModel model);

        /// <summary>
        /// Gets the transaction with the given identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TransactionViewModel> Get(int id);

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PagingResponse<TransactionViewModel>> Get(TransactionSearchViewModel request);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Gets the modified.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PagingResponse<TransactionViewModel>> GetModified(TransactionSearchViewModel request);
    }
}