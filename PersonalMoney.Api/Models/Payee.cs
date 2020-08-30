using Google.Cloud.Firestore;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Payee Model
    /// </summary>
    /// <seealso cref="NameModel" />
    [FirestoreData]
    public class Payee : NameModel
    {
    }
}