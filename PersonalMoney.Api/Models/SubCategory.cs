using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    internal class SubCategory : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("categoryId")]
        public int CategoryId { get; set; }
    }
}