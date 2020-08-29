using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// AccountTypeViewModel
    /// </summary>
    /// <seealso cref="NameViewModel" />
    public class AccountTypeViewModel : NameViewModel
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon { get; set; }
    }
}