namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    ///  Name ViewModel
    /// </summary>
    /// <seealso cref="StatusViewModel" />
    public class NameViewModel : StatusViewModel
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