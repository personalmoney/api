using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    internal class Tag : TimeModel
    {
        [FirestoreProperty("Name")]
        public string Name { get; set; }
    }
}