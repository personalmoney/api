using MoneyManager.Api.ViewModels.Base;

namespace MoneyManager.Api.ViewModels
{
    /// <summary>
    /// AccountTypeViewModel
    /// </summary>
    /// <seealso cref="StatusViewModel" />
    public class AccountTypeViewModel : StatusViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}