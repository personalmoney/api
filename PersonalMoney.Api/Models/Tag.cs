using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Tag model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class Tag : NameModel
    {
    }
}