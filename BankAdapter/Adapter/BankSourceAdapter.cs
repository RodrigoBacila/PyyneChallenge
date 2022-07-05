using Application.DataTransfer;
using Application.Interfaces;
using Bank1.Integration;
using Bank2.Integration;
using static Bank2.Integration.Bank2AccountTransaction;

namespace BankAdapter.Adapter
{
    public class BankSourceAdapter : IBankSourceAdapter
    {
        private readonly Bank1AccountSource bank1AccountSource;
        private readonly Bank2AccountSource bank2AccountSource;

        public BankSourceAdapter()
        {
            bank1AccountSource = new Bank1AccountSource();
            bank2AccountSource = new Bank2AccountSource();
        }

        public async Task<List<BankAccountBalanceDto>> GetAccountBalancesAsync(long accountNumberOrId)
        {
            return new List<BankAccountBalanceDto>
            {
                await GetAccountBalanceByAccountIdAsync(accountNumberOrId),
                await GetAccountBalanceByAccountNumberAsync(accountNumberOrId)
            };
        }

        public async Task<List<AccountTransactionDto>> GetTransactionsAsync(long accountNumberOrId, DateTime fromDate, DateTime toDate)
        {
            var accountTransactions = new List<AccountTransactionDto>();

            accountTransactions.AddRange(await GetTransactionsByAccountIdAsync(accountNumberOrId, fromDate, toDate));
            accountTransactions.AddRange(await GetTransactionsByAccountNumberAsync(accountNumberOrId, fromDate, toDate));

            return accountTransactions;
        }

        private async Task<BankAccountBalanceDto> GetAccountBalanceByAccountIdAsync(long accountId)
        {
            return await Task.Run(() =>
            {
                return new BankAccountBalanceDto(bank1AccountSource.GetAccountBalance(accountId), bank1AccountSource.GetAccountCurrency(accountId));
            });
        }

        private async Task<BankAccountBalanceDto> GetAccountBalanceByAccountNumberAsync(long accountNumber)
        {
            return await Task.Run(() =>
            {
                var accountBalance = bank2AccountSource.GetBalance(accountNumber);

                return new BankAccountBalanceDto(
                    accountBalance.GetBalance(),
                    accountBalance.GetCurrency()
                );
            });
        }

        private async Task<List<AccountTransactionDto>> GetTransactionsByAccountIdAsync(long accountId, DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return bank1AccountSource.GetTransactions(accountId, fromDate, toDate)
                .Select(transaction => new AccountTransactionDto(transaction.GetAmount(), TranslateBank1TransactionType(transaction.GetType()), transaction.GetText()))
                .ToList();
            });
        }

        private async Task<List<AccountTransactionDto>> GetTransactionsByAccountNumberAsync(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                return bank2AccountSource.GetTransactions(accountNumber, fromDate, toDate)
                    .Select(transaction => new AccountTransactionDto(transaction.GetAmount(), TranslateBank2TransactionType(transaction.GetType()), transaction.GetText()))
                    .ToList();
            });
        }

        private static string TranslateBank1TransactionType(int bank1TransactionType)
        {
            return bank1TransactionType switch
            {
                1 => "CREDIT",
                _ => "DEBIT"
            };
        }

        private static string TranslateBank2TransactionType(TRANSACTION_TYPES bank2TransactionType)
        {
            return bank2TransactionType switch
            {
                TRANSACTION_TYPES.CREDIT => "CREDIT",
                _ => "DEBIT",
            };
        }
    }
}
