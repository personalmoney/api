using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    [FirestoreData]
    internal class BaseModel
    {
        [FirestoreProperty("id")]
        public int Id { get; set; }
    }
}