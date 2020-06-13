using Google.Cloud.Firestore;
using Google.Type;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    [FirestoreData]
    internal class Account : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("type")]
        public int Type { get; set; }

        [FirestoreProperty("initialBalance")]
        public decimal InitialBalance { get; set; }

        [FirestoreProperty("minimumBalance")]
        public decimal MinimumBalance { get; set; }

        [FirestoreProperty("creditLimit")]
        public decimal CreditLimit { get; set; }

        [FirestoreProperty("paymentDate")]
        public Date PaymentDate { get; set; }

        [FirestoreProperty("interestRate")]
        public decimal InterestRate { get; set; }

        [FirestoreProperty("includeInBalance")]
        public bool IncludeInBalance { get; set; }
    }
}