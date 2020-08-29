using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// Name model
    /// </summary>
    /// <seealso cref="StatusModel" />
    public class NameModel : StatusModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}