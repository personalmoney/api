using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    [FirestoreData]
    internal class Tag : TimeModel
    {
        [FirestoreProperty("Name")]
        public string Name { get; set; }
    }
}