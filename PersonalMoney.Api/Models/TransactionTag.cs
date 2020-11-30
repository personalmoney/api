using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class TransactionTag : TimeModel
    {
        [FirestoreProperty("tagId")]
        public string TagId { get; set; }
    }
}