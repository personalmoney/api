using System;
using Google.Cloud.Firestore;

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
        [FirestoreProperty("createTime")]
        public DateTime? CreatedTime { get; internal set; }

        /// <summary>
        /// Gets the updated time.
        /// </summary>
        /// <value>
        /// The updated time.
        /// </value>
        [FirestoreProperty("updateTime")]
        public DateTime? UpdatedTime { get; internal set; }
    }
}