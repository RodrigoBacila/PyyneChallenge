using Application.BankingService;
using Application.DataTransfer;
using Application.Interfaces;

namespace UnitTests.Services
{
    public class BankServiceTests
    {
        private readonly IWindsorContainer windsorContainer;
        private readonly BankService bankService;

        public BankServiceTests()
        {
            windsorContainer = new WindsorContainer();
            windsorContainer.Install(new BaseInstaller<BankService>());
            bankService = windsorContainer.Resolve<BankService>();
        }

        [Fact(DisplayName = "Get Account Balances returns successful operation")]
        [Trait("Context", "Account Balance")]
        public async Task GetAccountBalances_ReturnsSuccessfulOperation()
        {
            windsorContainer
                .Resolve<Mock<IBankSourceAdapter>>()
                .Setup(adapter => adapter.GetAccountBalancesAsync(It.IsAny<long>()))
                .ReturnsAsync(new List<BankAccountBalanceDto>() { MockData.AccountBalanceData.RandomAccountBalanceData() });

            var result = await bankService.GetAccountBalancesAsync(It.IsAny<long>());

            var successfulOperation = result
                .Should()
                .BeOfType<SuccessfulOperation<List<BankAccountBalanceDto>>>()
                .Subject;

            successfulOperation
                .Result
                .Should()
                .NotBeNull();
        }

        [Fact(DisplayName = "Get Account Balances returns failed operation if no account could be found")]
        [Trait("Context", "Account Balance")]
        public async Task GetAccountBalances_ReturnsFailedOperation_IfNoAccountCouldBeFound()
        {
            windsorContainer
                .Resolve<Mock<IBankSourceAdapter>>()
                .Setup(adapter => adapter.GetAccountBalancesAsync(It.IsAny<long>()))
                .ReturnsAsync(new List<BankAccountBalanceDto>());

            var result = await bankService.GetAccountBalancesAsync(It.IsAny<long>());

            var failedOperation = result
                .Should()
                .BeOfType<FailedOperation<List<BankAccountBalanceDto>>>()
                .Subject;

            failedOperation
                .WasBecauseTargetCouldNotBeFound()
                .Should()
                .BeTrue();
        }

        [Fact(DisplayName = "Get Account Transactions returns successful operation")]
        [Trait("Context", "Account Transactions")]
        public async Task GetAccountTransactions_ReturnsSuccessfulOperation()
        {
            windsorContainer
                .Resolve<Mock<IBankSourceAdapter>>()
                .Setup(adapter => adapter.GetTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new List<AccountTransactionDto>() { MockData.AccountTransactionsData.RandomTransactionData() });

            var result = await bankService.GetAccountTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            var successfulOperation = result
                .Should()
                .BeOfType<SuccessfulOperation<List<AccountTransactionDto>>>()
                .Subject;

            successfulOperation
                .Result
                .Should()
                .NotBeNull();
        }

        [Fact(DisplayName = "Get Account Transactions returns failed operation in case of error")]
        [Trait("Context", "Account Transactions")]
        public async Task GetAccountTransactions_ReturnsFailedOperation_InCaseOfError()
        {
            windsorContainer
                .Resolve<Mock<IBankSourceAdapter>>()
                .Setup(adapter => adapter.GetTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(It.IsAny<List<AccountTransactionDto>>());

            var result = await bankService.GetAccountTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            var failedOperation = result
                .Should()
                .BeOfType<FailedOperation<List<AccountTransactionDto>>>()
                .Subject;

            failedOperation
                .WasBecauseOfInternalError()
                .Should()
                .BeTrue();
        }
    }
}
