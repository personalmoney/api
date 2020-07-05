using System;
using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    internal class TimeModel : UserModel
    {
        [FirestoreProperty("createTime")]
        public DateTime? CreatedTime { get; internal set; }

        [FirestoreProperty("updateTime")]
        public DateTime? UpdatedTime { get; internal set; }
    }
}