using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    public class AccountType : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}