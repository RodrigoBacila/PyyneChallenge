using Application.DataTransfer;
using Framework;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Api Operations Controller
    /// </summary>
    public class ApiOperationsController : ControllerBase
    {
        /// <summary>
        /// Gets the correspondent response type for the provided operation result
        /// </summary>
        /// <typeparam name="T">The response object type</typeparam>
        /// <param name="operation">The operation result</param>
        /// <param name="successResponse">The default response for successful cases</param>
        /// <returns>An action result that matches the specified operation result</returns>
        protected IActionResult GetAdequateResponseTypeForOperationResult<T>(IOperation<T> operation, Func<object?, ActionResult> successResponse)
        {
            if (operation is FailedOperation failedOperation)
            {
                // This type of failure would be one possibility, but it was not implemented in the present project, since there is no input validation
                if (failedOperation.WasBecauseOfValidationIssues())
                    return BadRequest(failedOperation.Error);

                if (failedOperation.WasBecauseTargetCouldNotBeFound())
                    return NotFound(failedOperation.Error);

                if (failedOperation.WasBecauseOfInternalError())
                    return StatusCode(StatusCodes.Status500InternalServerError, failedOperation.Error);
            }

            // This next part was implemented to respect the test rules about printing the results to the console
            if (operation is SuccessfulOperation<List<BankAccountBalanceDto>> successfulAccountBalancesQueryOperation)
                PrintBalances(successfulAccountBalancesQueryOperation.Result);

            if (operation is SuccessfulOperation<List<AccountTransactionDto>> successfulAccountTransactionsQueryOperation)
                PrintTransactions(successfulAccountTransactionsQueryOperation.Result);

            return successResponse(operation as SuccessfulOperation<T>);
        }

        /// <summary>
        /// Prints all provided account balances information to the console
        /// </summary>
        /// <param name="accountBalances">The account balances data</param>
        private static void PrintBalances(List<BankAccountBalanceDto> accountBalances)
        {
            if (accountBalances == null)
                return;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("** ACCOUNT BALANCES **");
            Console.WriteLine();

            foreach (var accountBalance in accountBalances)
            {
                if (accountBalance.IsNegative())
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{accountBalances.IndexOf(accountBalance)} - {accountBalance}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--- --- --- --- --- --- --- --- --- --- ---");
        }

        /// <summary>
        /// Prints all provided account transactions information to the console
        /// </summary>
        /// <param name="transactions">The account transactions data</param>
        private static void PrintTransactions(List<AccountTransactionDto> transactions)
        {
            if (transactions == null)
                return;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("** TRANSACTIONS **");
            Console.WriteLine();

            foreach (var transaction in transactions)
            {
                if (transaction.IsDebitTransaction())
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{transactions.IndexOf(transaction)} - {transaction}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--- --- --- --- --- --- --- --- --- --- ---");
        }
    }
}