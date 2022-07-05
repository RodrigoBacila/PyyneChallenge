using Application.DataTransfer;
using Framework;

namespace Application.Interfaces
{
    /// <summary>
    /// Bank Service Interface
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Gets Account Transactions Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <param name="fromDate">Starting date for data fetch (not implemented for the current project)</param>
        /// <param name="toDate">Ending date for data fetch (not implemented for the current project)</param>
        /// <returns>A successful operation result containing the list of all relevant account transactions data; or a failed operation result with an error</returns>
        Task<IOperation<List<AccountTransactionDto>>> GetAccountTransactionsAsync(long accountNumberOrId, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets Account Balances Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <returns>A successful operation result containing the list of all relevant account balances data; or a failed operation result with an error</returns>
        Task<IOperation<List<BankAccountBalanceDto>>> GetAccountBalancesAsync(long accountNumberOrId);
    }
}
