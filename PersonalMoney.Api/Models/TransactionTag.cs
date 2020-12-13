using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Transaction tags
    /// </summary>
    /// <seealso cref="TimeModel" />
    public class TransactionTag : TimeModel
    {
        /// <summary>
        /// Gets or sets the tag identifier.
        /// </summary>
        /// <value>
        /// The tag identifier.
        /// </value>
        public int TagId { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public Tag Tag { get; set; }
    }
}