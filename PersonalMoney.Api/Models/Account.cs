using Google.Cloud.Firestore;
using Google.Type;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class Account : StatusModel
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("type")]
        public string Type { get; set; }

        [FirestoreProperty("initialBalance")]
        public double InitialBalance { get; set; }

        [FirestoreProperty("minimumBalance")]
        public double MinimumBalance { get; set; }

        [FirestoreProperty("creditLimit")]
        public double CreditLimit { get; set; }

        [FirestoreProperty("paymentDate")]
        public Date PaymentDate { get; set; }

        [FirestoreProperty("interestRate")]
        public double InterestRate { get; set; }

        [FirestoreProperty("includeInBalance")]
        public bool IncludeInBalance { get; set; }
    }
}