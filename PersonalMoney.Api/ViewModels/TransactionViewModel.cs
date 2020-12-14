using System.Collections.Generic;

namespace PersonalMoney.Api.ViewModels
{
    /// <summary>
    /// Transaction view model
    /// </summary>
    /// <seealso cref="TransactionRequestModel" />
    public class TransactionViewModel : TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionViewModel"/> class.
        /// </summary>
        public TransactionViewModel()
        {
            Tags = new List<TagViewModel>();
        }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// To account name.
        /// </summary>
        /// <value>
        /// The name of to account.
        /// </value>
        public string ToAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sub category.
        /// </summary>
        /// <value>
        /// The name of the sub category.
        /// </value>
        public string SubCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the payee.
        /// </summary>
        /// <value>
        /// The name of the payee.
        /// </value>
        public string PayeeName { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public IList<TagViewModel> Tags { get; set; }
    }
}