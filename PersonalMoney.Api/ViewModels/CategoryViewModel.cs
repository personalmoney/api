using PersonalMoney.Api.ViewModels.Base;
using System.Collections.Generic;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Category View Model
    /// </summary>
    /// <seealso cref="NameViewModel" />
    public class CategoryViewModel : NameViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryViewModel"/> class.
        /// </summary>
        public CategoryViewModel()
        {
            SubCategories = new List<SubCategoryViewModel>();
        }

        /// <summary>
        /// Gets the sub categories.
        /// </summary>
        /// <value>
        /// The sub categories.
        /// </value>
        public IList<SubCategoryViewModel> SubCategories { get; }
    }
}