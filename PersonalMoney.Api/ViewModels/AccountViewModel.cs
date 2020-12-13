﻿using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Account View Model
    /// </summary>
    /// <seealso cref="NameViewModel" />
    public class AccountViewModel : NameViewModel
    {
        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public int AccountType { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; set; }

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
        public int? PaymentDate { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether to exclude this account from dashboard.
        /// </summary>
        /// <value>
        ///   <c>true</c> if need to exclude from this account dashboard; otherwise, <c>false</c>.
        /// </value>
        public bool ExcludeFromDashboard { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this account is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}