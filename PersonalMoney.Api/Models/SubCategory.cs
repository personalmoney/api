using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// SubCategory Model
    /// </summary>
    /// <seealso cref="NameModel" />
    public class SubCategory : NameModel
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public Category Category { get; set; }
    }
}