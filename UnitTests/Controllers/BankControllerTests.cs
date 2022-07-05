using Api.Controllers;
using Application.DataTransfer;
using Application.Interfaces;

namespace UnitTests.Controllers
{
    public class BankControllerTests
    {
        private readonly IWindsorContainer windsorContainer;
        private readonly BankController bankController;

        public BankControllerTests()
        {
            windsorContainer = new WindsorContainer();
            windsorContainer.Install(new BaseInstaller<BankController>());
            bankController = windsorContainer.Resolve<BankController>();
        }

        [Fact(DisplayName = "Get account balances returns HTTP 200 Ok")]
        [Trait("Context", "Account Balance")]
        public async Task GetAccountBalancesAsync_ReturnsStatus200Ok_For_Successful_Requests()
        {
            windsorContainer
                .Resolve<Mock<IBankService>>()
                .Setup(service => service.GetAccountBalancesAsync(It.IsAny<long>()))
                .ReturnsAsync(new SuccessfulOperation<List<BankAccountBalanceDto>>(new List<BankAccountBalanceDto>()));

            windsorContainer
                .Resolve<Mock<ApiOperationsController>>();

            var response = await bankController.GetAccountBalancesAsync(It.IsAny<long>());

            response
                .Should()
                .BeOfType<OkObjectResult>();

            var responseSubject = response
                .Should()
                .BeOfType<OkObjectResult>()
                .Subject;

            responseSubject
                .StatusCode
                .Should()
                .Be(StatusCodes.Status200OK);
        }

        [Fact(DisplayName = "Get account balances returns HTTP 404 NotFound")]
        [Trait("Context", "Account Balance")]
        public async Task GetAccountBalancesAsync_ReturnsStatus404NotFound_When_No_Account_Can_Be_Found()
        {
            windsorContainer
                .Resolve<Mock<IBankService>>()
                .Setup(service => service.GetAccountBalancesAsync(It.IsAny<long>()))
                .ReturnsAsync(new FailedOperation<List<BankAccountBalanceDto>>(It.IsAny<string>(), FailureCause.NotFound));

            windsorContainer
                .Resolve<Mock<ApiOperationsController>>();

            var response = await bankController.GetAccountBalancesAsync(It.IsAny<long>());

            response
                .Should()
                .BeOfType<NotFoundObjectResult>();

            var responseSubject = response
                .Should()
                .BeOfType<NotFoundObjectResult>()
                .Subject;

            responseSubject
                .StatusCode
                .Should()
                .Be(StatusCodes.Status404NotFound);
        }

        [Fact(DisplayName = "Get account transactions returns HTTP 200 Ok")]
        [Trait("Context", "Account Transactions")]
        public async Task GetAccountTransactionsAsync_ReturnsStatus200Ok_For_Successful_Requests()
        {
            windsorContainer
                .Resolve<Mock<IBankService>>()
                .Setup(service => service.GetAccountTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new SuccessfulOperation<List<AccountTransactionDto>>(new List<AccountTransactionDto>()));

            windsorContainer
                .Resolve<Mock<ApiOperationsController>>();

            var response = await bankController.GetAccountTransactionsAsync(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            response
                .Should()
                .BeOfType<OkObjectResult>();

            var responseSubject = response
                .Should()
                .BeOfType<OkObjectResult>()
                .Subject;

            responseSubject
                .StatusCode
                .Should()
                .Be(StatusCodes.Status200OK);
        }
    }
}