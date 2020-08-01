using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    internal class UserModel : BaseModel
    {
        [FirestoreProperty("userId")]
        public string UserId { get; set; }
    }
}