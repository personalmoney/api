namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    /// Status viewModel
    /// </summary>
    /// <seealso cref="TimeViewModel" />
    public class StatusViewModel : TimeViewModel
    {
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool? IsActive { get; set; }
    }
}