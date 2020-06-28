using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    [FirestoreData]
    internal class BaseModel
    {
        public string Id { get; set; }
    }
}