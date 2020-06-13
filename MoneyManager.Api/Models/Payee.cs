using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    internal class Payee : TimeModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}