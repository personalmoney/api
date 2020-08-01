using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    internal class Payee : TimeModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}