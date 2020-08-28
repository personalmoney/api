using System;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Account View Model
    /// </summary>
    /// <seealso cref="StatusViewModel" />
    public class AccountViewModel : StatusViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets the initial balance.
        /// </summary>
        /// <value>
        /// The initial balance.
        /// </value>
        public decimal InitialBalance { get; set; }

        /// <summary>
        /// Gets or sets the minimum balance.
        /// </summary>
        /// <value>
        /// The minimum balance.
        /// </value>
        public decimal MinimumBalance { get; set; }

        /// <summary>
        /// Gets or sets the credit limit.
        /// </summary>
        /// <value>
        /// The credit limit.
        /// </value>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the interest rate.
        /// </summary>
        /// <value>
        /// The interest rate.
        /// </value>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [include balance].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [include balance]; otherwise, <c>false</c>.
        /// </value>
        public bool IncludeInBalance { get; set; }
    }
}