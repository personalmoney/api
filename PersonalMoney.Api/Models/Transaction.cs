using System.Collections.Generic;
using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;
using DateTime = System.DateTime;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class Transaction : TimeModel
    {
        public Transaction() : this(new List<SubTransaction>(), new List<TransactionTag>())
        {
        }

        public Transaction(IList<SubTransaction> subTransactions, IList<TransactionTag> tags)
        {
            SubTransactions = subTransactions;
            Tags = tags;
        }

        [FirestoreProperty("accountId")]
        public string AccountId { get; set; }

        [FirestoreProperty("toAccountId")]
        public string ToAccountId { get; set; }

        [FirestoreProperty("subCategoryId")]
        public string SubCategoryId { get; set; }

        [FirestoreProperty("payeeId")]
        public string PayeeId { get; set; }

        [FirestoreProperty("status")]
        public string Status { get; set; }

        [FirestoreProperty("date")]
        public DateTime? Date { get; set; }

        [FirestoreProperty("amount")]
        public double Amount { get; set; }

        [FirestoreProperty("toAmount")]
        public double ToAmount { get; set; }

        [FirestoreProperty("type")]
        public string Type { get; set; }

        [FirestoreProperty("notes")]
        public string Notes { get; set; }

        [FirestoreProperty("number")]
        public string Number { get; set; }

        [FirestoreProperty("subTransactions")]
        public IList<SubTransaction> SubTransactions { get; }

        [FirestoreProperty("tags")]
        public IList<TransactionTag> Tags { get; }
    }
}