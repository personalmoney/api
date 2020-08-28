using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Account Type database model
    /// </summary>
    /// <seealso cref="StatusModel" />
    [FirestoreData]
    public class AccountType : StatusModel
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
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [FirestoreProperty("icon")]
        public string Icon { get; set; }
    }
}