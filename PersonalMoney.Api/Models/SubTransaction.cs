using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class SubTransaction : TimeModel
    {
        [FirestoreProperty("transactionId")]
        public int TransactionId { get; set; }

        [FirestoreProperty("subCategoryId")]
        public int SubCategoryId { get; set; }

        [FirestoreProperty("payeeId")]
        public int PayeeId { get; set; }

        [FirestoreProperty("amount")]
        public double Amount { get; set; }
    }
}