using Google.Cloud.Firestore;
using Google.Type;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    internal class Transaction : TimeModel
    {
        [FirestoreProperty("accountId")]
        public int AccountId { get; set; }

        [FirestoreProperty("toAccountId")]
        public int ToAccountId { get; set; }

        [FirestoreProperty("subCategoryId")]
        public int SubCategoryId { get; set; }

        [FirestoreProperty("payeeId")]
        public int PayeeId { get; set; }

        [FirestoreProperty("status")]
        public string Status { get; set; }

        [FirestoreProperty("date")]
        public Date Date { get; set; }

        [FirestoreProperty("amount")]
        public decimal Amount { get; set; }

        [FirestoreProperty("toAmount")]
        public decimal ToAmount { get; set; }

        [FirestoreProperty("type")]
        public string Type { get; set; }

        [FirestoreProperty("notes")]
        public string Notes { get; set; }

        [FirestoreProperty("number")]
        public string Number { get; set; }
    }
}