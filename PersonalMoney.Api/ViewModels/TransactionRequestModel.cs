using System;
using System.Collections.Generic;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Transaction view model
    /// </summary>
    /// <seealso cref="TimeViewModel" />
    public class TransactionRequestModel : TimeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRequestModel"/> class.
        /// </summary>
        public TransactionRequestModel()
        {
            TagIds = new List<int>();
        }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Converts to account.
        /// </summary>
        /// <value>
        /// To account.
        /// </value>
        public int? ToAccountId { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public int SubCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>
        /// The payee.
        /// </value>
        public int PayeeId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public ICollection<int> TagIds { get; set; }
    }
}