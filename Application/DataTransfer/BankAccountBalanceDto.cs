namespace Application.DataTransfer
{
    /// <summary>
    /// Data Transfer Object for Bank Account Balances
    /// </summary>
    public class BankAccountBalanceDto
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="balance">The current balance</param>
        /// <param name="currency">The currency</param>
        public BankAccountBalanceDto(double balance, string currency)
        {
            Balance = balance;
            Currency = currency;
        }

        public double Balance { get; }
        public string Currency { get; }

        /// <summary>
        /// Checks wether the current balance is negative
        /// </summary>
        /// <returns>True if negative; false otherwise</returns>
        public bool IsNegative()
        {
            return Balance < 0;
        }

        public override string ToString()
        {
            return $"{Currency} {Balance}";
        }
    }
}
