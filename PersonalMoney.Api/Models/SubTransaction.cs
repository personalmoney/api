using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Sub transaction model
    /// </summary>
    /// <seealso cref="TimeModel" />
    public class SubTransaction : TimeModel
    {
        /// <summary>
        /// Gets or sets the sub category identifier.
        /// </summary>
        /// <value>
        /// The sub category identifier.
        /// </value>
        public int SubCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the payee identifier.
        /// </summary>
        /// <value>
        /// The payee identifier.
        /// </value>
        public int PayeeId { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public SubCategory SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>
        /// The payee.
        /// </value>
        public Payee Payee { get; set; }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        public Transaction Transaction { get; set; }
    }
}