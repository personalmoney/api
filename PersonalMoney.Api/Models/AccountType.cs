using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Account Type database model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class AccountType : NameModel
    {
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