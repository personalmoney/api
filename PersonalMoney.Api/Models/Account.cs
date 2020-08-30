using Google.Cloud.Firestore;
using Google.Type;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Account Model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class Account : NameModel
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [FirestoreProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the initial balance.
        /// </summary>
        /// <value>
        /// The initial balance.
        /// </value>
        [FirestoreProperty("initialBalance")]
        public double InitialBalance { get; set; }

        /// <summary>
        /// Gets or sets the minimum balance.
        /// </summary>
        /// <value>
        /// The minimum balance.
        /// </value>
        [FirestoreProperty("minimumBalance")]
        public double MinimumBalance { get; set; }

        /// <summary>
        /// Gets or sets the credit limit.
        /// </summary>
        /// <value>
        /// The credit limit.
        /// </value>
        [FirestoreProperty("creditLimit")]
        public double CreditLimit { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        [FirestoreProperty("paymentDate")]
        public Date PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the interest rate.
        /// </summary>
        /// <value>
        /// The interest rate.
        /// </value>
        [FirestoreProperty("interestRate")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include the account value in balance calculation.
        /// </summary>
        /// <value>
        ///   <c>true</c> to include in balance calculation; otherwise, <c>false</c>.
        /// </value>
        [FirestoreProperty("includeInBalance")]
        public bool IncludeInBalance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this Account is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [FirestoreProperty("isActive")]
        public bool IsActive { get; set; }
    }
}