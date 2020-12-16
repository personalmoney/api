using System.ComponentModel.DataAnnotations;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// User Model
    /// </summary>
    /// <seealso cref="BaseModel" />
    public class UserModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [MaxLength(100)]
        public string UserId { get; set; }
    }
}