using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// SubCategory Model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class SubCategory : NameModel
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        [FirestoreProperty("categoryId")]
        public string CategoryId { get; set; }
    }
}