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
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }
    }
}