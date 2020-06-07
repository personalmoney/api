using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    public class SubCategory : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("categoryId")]
        public int CategoryId { get; set; }
    }
}