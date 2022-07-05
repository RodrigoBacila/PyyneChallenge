using Application.DataTransfer;
using Application.Interfaces;
using Framework;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Bank Controller
    /// </summary>
    [EndpointGroupName("Bank")]
    [ApiController, Route("api/v1/bank"), Produces("application/json")]
    public class BankController : ApiOperationsController
    {
        private readonly IBankService bankService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bankService">Injected dependency for the bank service interface</param>
        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }

        /// <summary>
        /// Gets account balances information
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <returns>A list of all relevant account balances data</returns>
        [HttpGet("balances", Name = "GetAccountBalances")]
        [ProducesResponseType(typeof(List<BankAccountBalanceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountBalancesAsync(long accountNumberOrId)
        {
            var accountBalances = await bankService.GetAccountBalancesAsync(accountNumberOrId);

            return GetAdequateResponseTypeForOperationResult(accountBalances, Ok);
        }

        /// <summary>
        /// Gets account transactions information
        /// </summary>
        /// <param name="accountNumberOrId">Account number or ID for data fetch (not implemented for the current project)</param>
        /// <param name="fromDate">Starting date for data fetch (not implemented for the current project)</param>
        /// <param name="toDate">Ending date for data fetch (not implemented for the current project)</param>
        /// <returns>A list of all relevant account transactions data</returns>
        [HttpGet("transactions", Name = "GetAccountTransactions")]
        [ProducesResponseType(typeof(List<AccountTransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountTransactionsAsync(long accountNumberOrId, DateTime fromDate, DateTime toDate)
        {
            var transactions = await bankService.GetAccountTransactionsAsync(accountNumberOrId, fromDate, toDate);

            return GetAdequateResponseTypeForOperationResult(transactions, Ok);
        }
    }
}