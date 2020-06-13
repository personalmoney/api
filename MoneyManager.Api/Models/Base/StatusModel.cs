using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    internal class StatusModel : TimeModel
    {
        [FirestoreProperty("active")]
        public bool IsActive { get; set; }
    }
}