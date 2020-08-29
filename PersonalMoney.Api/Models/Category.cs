using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Category Model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class Category : NameModel
    {
    }
}