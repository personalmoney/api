using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class SubCategory : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("categoryId")]
        public string CategoryId { get; set; }
    }
}