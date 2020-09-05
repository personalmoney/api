using Google.Cloud.Firestore;

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
        [FirestoreProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name lower case.
        /// </summary>
        /// <value>
        /// The name lower case.
        /// </value>
        [FirestoreProperty("name_lowercase")]
        public string NameLowerCase { get; set; }
    }
}