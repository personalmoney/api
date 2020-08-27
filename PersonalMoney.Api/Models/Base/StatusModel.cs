using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// Status Model
    /// </summary>
    /// <seealso cref="TimeModel" />
    public class StatusModel : TimeModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [FirestoreProperty("active")]
        public bool IsActive { get; set; }
    }
}