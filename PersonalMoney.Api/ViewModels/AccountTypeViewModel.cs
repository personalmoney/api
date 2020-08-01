using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
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