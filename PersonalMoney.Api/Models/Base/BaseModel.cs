using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// Base Model
    /// </summary>
    [FirestoreData]
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        [FirestoreProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}