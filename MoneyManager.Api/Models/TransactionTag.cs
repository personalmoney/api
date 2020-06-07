using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Models
{
    public class TransactionTag : TimeModel
    {
        public int TransactionId { get; set; }
        public int TagId { get; set; }
    }
}