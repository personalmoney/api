using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// SubCategory ViewModel
    /// </summary>
    /// <seealso cref="NameViewModel" />
    public class SubCategoryViewModel : NameViewModel
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }
    }
}