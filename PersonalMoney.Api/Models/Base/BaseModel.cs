using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    [FirestoreData]
    internal class BaseModel
    {
        public string Id { get; set; }

        [FirestoreProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}