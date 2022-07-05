using Application.DataTransfer;
using Application.Interfaces;
using Framework;

namespace Application.BankingService
{
    public class BankService : IBankService
    {
        private readonly IBankSourceAdapter bankAdapter;

        public BankService(IBankSourceAdapter bankAdapter)
        {
            this.bankAdapter = bankAdapter;
        }

        /// <summary>
        /// Gets Account Balances Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <returns>A successful operation result containing the list of all relevant account balances data; or a failed operation result with an error</returns>
        public async Task<IOperation<List<BankAccountBalanceDto>>> GetAccountBalancesAsync(long accountNumberOrId)
        {
            var accountBalances = await bankAdapter.GetAccountBalancesAsync(accountNumberOrId);

            if (accountBalances == null || !accountBalances.Any())
                return new FailedOperation<List<BankAccountBalanceDto>>(ErrorMessages.ProvidedAccountNotFound, FailureCause.NotFound);

            return new SuccessfulOperation<List<BankAccountBalanceDto>>(accountBalances);
        }

        /// <summary>
        /// Gets Account Transactions Asynchronously
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <param name="fromDate">Starting date for data fetch (not implemented for the current project)</param>
        /// <param name="toDate">Ending date for data fetch (not implemented for the current project)</param>
        /// <returns>A successful operation result containing the list of all relevant account transactions data; or a failed operation result with an error</returns>
        public async Task<IOperation<List<AccountTransactionDto>>> GetAccountTransactionsAsync(long accountNumberOrId, DateTime fromDate, DateTime toDate)
        {
            var transactions = await bankAdapter.GetTransactionsAsync(accountNumberOrId, fromDate, toDate);

            if (transactions == null)
                return new FailedOperation<List<AccountTransactionDto>>(ErrorMessages.InternalError, FailureCause.InternalError);

            return new SuccessfulOperation<List<AccountTransactionDto>>(transactions);
        }
    }
}
