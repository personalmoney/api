namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    ///  Name ViewModel
    /// </summary>
    /// <seealso cref="TimeViewModel" />
    public class NameViewModel : TimeViewModel
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