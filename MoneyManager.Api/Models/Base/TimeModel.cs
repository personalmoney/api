using System;
using Google.Cloud.Firestore;

namespace MoneyManager.Api.Models.Base
{
    internal class TimeModel : UserModel
    {
        [FirestoreProperty("createTime")]
        public DateTime CreateTime { get; set; }

        [FirestoreProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}