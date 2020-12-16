using System;

namespace PersonalMoney.Api.Models.Base
{
    /// <summary>
    /// Time Model
    /// </summary>
    /// <seealso cref="UserModel" />
    public class TimeModel : UserModel
    {
        /// <summary>
        /// Gets the created time.
        /// </summary>
        /// <value>
        /// The created time.
        /// </value>
        public DateTime? CreatedTime { get; internal set; }

        /// <summary>
        /// Gets the updated time.
        /// </summary>
        /// <value>
        /// The updated time.
        /// </value>
        public DateTime? UpdatedTime { get; internal set; }
    }
}