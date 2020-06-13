using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    internal class SubTransaction : TimeModel
    {
        [FirestoreProperty("transactionId")]
        public int TransactionId { get; set; }

        [FirestoreProperty("subCategoryId")]
        public int SubCategoryId { get; set; }

        [FirestoreProperty("payeeId")]
        public int PayeeId { get; set; }

        [FirestoreProperty("amount")]
        public decimal Amount { get; set; }
    }
}