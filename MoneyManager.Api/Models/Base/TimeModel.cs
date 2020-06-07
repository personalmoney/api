using Google.Cloud.Firestore;
using System;

namespace MoneyManager.Api.Models.Base
{
    public class TimeModel : UserModel
    {
        [FirestoreProperty("createTime")]
        public DateTime CreateTime { get; set; }

        [FirestoreProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}