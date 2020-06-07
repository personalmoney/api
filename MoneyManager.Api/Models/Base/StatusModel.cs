using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    public class StatusModel : TimeModel
    {
        [FirestoreProperty("active")]
        public bool IsActive { get; set; }
    }
}