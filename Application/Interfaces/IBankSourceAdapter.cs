using Application.DataTransfer;

namespace Application.Interfaces
{
    /// <summary>
    /// Bank Source Adapter Interface
    /// </summary>
    public interface IBankSourceAdapter
    {
        /// <summary>
        /// Gets Account Transactions Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <param name="fromDate">Starting date for data fetch (not implemented for the current project)</param>
        /// <param name="toDate">Ending date for data fetch (not implemented for the current project)</param>
        /// <returns>A list of all relevant account transactions data</returns>
        Task<List<AccountTransactionDto>> GetTransactionsAsync(long accountNumberOrId, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets Account Balances Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <returns>A list of all relevant account balances data</returns>
        Task<List<BankAccountBalanceDto>> GetAccountBalancesAsync(long accountNumberOrId);
    }
}
