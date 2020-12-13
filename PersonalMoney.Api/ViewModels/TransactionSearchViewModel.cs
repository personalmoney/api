using System;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Transaction search view model
    /// </summary>
    /// <seealso cref="PagingRequest" />
    public class TransactionSearchViewModel : PagingRequest
    {
        /// <summary>
        /// Gets or sets the last synchronize time.
        /// </summary>
        /// <value>
        /// The last synchronize time.
        /// </value>
        public DateTime? LastSyncTime { get; set; }
    }
}