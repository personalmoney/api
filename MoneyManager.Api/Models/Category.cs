using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    internal class Category : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}