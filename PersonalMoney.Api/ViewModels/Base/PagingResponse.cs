using System.Collections.Generic;

namespace PersonalMoney.Api.ViewModels.Base
{
    /// <summary>
    /// Pagination repsonse base model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagingResponse{T}"/> class.
        /// </summary>
        public PagingResponse() : this(new List<T>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingResponse{T}"/> class.
        /// </summary>
        /// <param name="records">The records.</param>
        public PagingResponse(IEnumerable<T> records)
        {
            Records = records;
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        /// <value>
        /// The total records.
        /// </value>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the records.
        /// </summary>
        /// <value>
        /// The records.
        /// </value>
        public IEnumerable<T> Records { get; set; }
    }
}