using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class Category : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}