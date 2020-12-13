using System.ComponentModel.DataAnnotations;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// Name model
    /// </summary>
    /// <seealso cref="TimeModel" />
    public class NameModel : TimeModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(100)]
        public string Name { get; set; }
    }
}