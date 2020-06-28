using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    [FirestoreData]
    internal class AccountType : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}