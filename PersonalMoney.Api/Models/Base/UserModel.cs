using Google.Cloud.Firestore;

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
        [FirestoreProperty("userId")]
        public string UserId { get; set; }
    }
}