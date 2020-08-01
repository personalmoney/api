using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Models
{
    internal class TransactionTag : TimeModel
    {
        public int TransactionId { get; set; }
        public int TagId { get; set; }
    }
}