using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    internal class UserModel : BaseModel
    {
        [FirestoreProperty("userId")]
        public string UserId { get; set; }
    }
}