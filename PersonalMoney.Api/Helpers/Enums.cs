namespace PersonalMoney.Api.Helpers
{
    /// <summary>
    /// Transaction type
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// The deposit
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// The withdrawal
        /// </summary>
        Withdrawal = 2,

        /// <summary>
        /// The transfer
        /// </summary>
        Transfer = 3
    }
}