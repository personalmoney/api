using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Transaction model
    /// </summary>
    /// <seealso cref="TimeModel" />
    public class Transaction : TimeModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction() : this(new List<SubTransaction>(), new List<TransactionTag>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="subTransactions">The sub transactions.</param>
        /// <param name="tags">The tags.</param>
        public Transaction(IList<SubTransaction> subTransactions, IList<TransactionTag> tags)
        {
            SubTransactions = subTransactions;
            Tags = tags;
        }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Converts to accountid.
        /// </summary>
        /// <value>
        /// To account identifier.
        /// </value>
        public int? ToAccountId { get; set; }

        /// <summary>
        /// Gets or sets the sub category identifier.
        /// </summary>
        /// <value>
        /// The sub category identifier.
        /// </value>
        public int? SubCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the payee identifier.
        /// </summary>
        /// <value>
        /// The payee identifier.
        /// </value>
        public int? PayeeId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [MaxLength(10)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Converts to amount.
        /// </summary>
        /// <value>
        /// To amount.
        /// </value>
        public double ToAmount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [MaxLength(20)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [MaxLength(500)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [MaxLength(100)]
        public string Number { get; set; }

        /// <summary>
        /// Gets the sub transactions.
        /// </summary>
        /// <value>
        /// The sub transactions.
        /// </value>
        public IList<SubTransaction> SubTransactions { get; }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public IList<TransactionTag> Tags { get; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public virtual Account Account { get; set; }

        /// <summary>
        /// Gets or sets the To account.
        /// </summary>
        /// <value>
        /// To account.
        /// </value>
        public virtual Account ToAccount { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public virtual SubCategory SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>
        /// The payee.
        /// </value>
        public virtual Payee Payee { get; set; }
    }
}