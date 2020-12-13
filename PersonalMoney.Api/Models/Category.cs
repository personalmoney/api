using System.Collections.Generic;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Category Model
    /// </summary>
    /// <seealso cref="NameModel" />
    public class Category : NameModel
    {
        private IList<SubCategory> SubCategories { get; set; }
    }
}