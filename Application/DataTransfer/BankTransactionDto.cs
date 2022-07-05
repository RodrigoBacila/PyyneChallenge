namespace Application.DataTransfer
{
    /// <summary>
    /// Data Transfer Object for Bank Transactions
    /// </summary>
    public class AccountTransactionDto
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="amount">The transaction amount</param>
        /// <param name="type">The transaction type</param>
        /// <param name="text">The transaction text or comment</param>
        public AccountTransactionDto(double amount, string type, string text)
        {
            Amount = amount;
            Type = type;
            Text = text;
        }

        public double Amount { get; }
        public string Type { get; }
        public string Text { get; }

        /// <summary>
        /// Checks wether the transaction is of the *debit* type
        /// </summary>
        /// <returns>True if debit type; false otherwise</returns>
        public bool IsDebitTransaction()
        {
            return Type.Equals("DEBIT", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{Type} >> {(IsDebitTransaction() ? "-" : "+")}{Amount} :: {Text}";
        }
    }
}
