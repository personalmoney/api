using System;

namespace MoneyManager.Api.ViewModels.Base
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
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        public DateTime? UpdateTime { get; set; }
    }
}