using System;

namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    /// Time viewModel
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class TimeViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        public DateTime? UpdatedTime { get; set; }
    }
}