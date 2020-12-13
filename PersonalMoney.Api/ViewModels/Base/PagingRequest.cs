namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    /// Paging request model
    /// </summary>
    public class PagingRequest
    {
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public int CurrentPage { get; set; } = 1;
    }
}