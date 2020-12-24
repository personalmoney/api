using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Account Type database model
    /// </summary>
    /// <seealso cref="NameModel" />
    public class AccountType : NameModel
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        [MaxLength(100)]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public ICollection<Account> Accounts { get; set; }
    }
}