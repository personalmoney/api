using Google.Cloud.Firestore;

namespace PersonalMoney.Api.Models.Base
{
    internal class StatusModel : TimeModel
    {
        [FirestoreProperty("active")]
        public bool IsActive { get; set; }
    }
}