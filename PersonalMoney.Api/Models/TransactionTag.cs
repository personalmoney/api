using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class TransactionTag : TimeModel
    {
        [FirestoreProperty("transactionId")]
        public string TransactionId { get; set; }

        [FirestoreProperty("tagId")]
        public string TagId { get; set; }
    }
}