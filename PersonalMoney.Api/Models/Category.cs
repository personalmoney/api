using System.Collections.Generic;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Category Model
    /// </summary>
    /// <seealso cref="NameModel" />
    public class Category : NameModel
    {
        /// <summary>
        /// Gets or sets the sub categories.
        /// </summary>
        /// <value>
        /// The sub categories.
        /// </value>
        public IList<SubCategory> SubCategories { get; set; }
    }
}