using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    public class UserModel : BaseModel
    {
        [FirestoreProperty("userId")]
        public string UserId { get; set; }
    }
}