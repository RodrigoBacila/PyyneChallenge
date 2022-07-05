using Application.DataTransfer;

namespace Tests.Shared
{
    public static class MockData
    {
        private static readonly Faker faker = new();

        public static class AccountBalanceData
        {
            public static BankAccountBalanceDto RandomAccountBalanceData()
            {
                return new BankAccountBalanceDto(faker.Random.Double(), faker.Finance.Currency().Code);
            }
        }

        public static class AccountTransactionsData
        {
            public static AccountTransactionDto RandomTransactionData()
            {
                return new AccountTransactionDto(
                    faker.Random.Double(), 
                    faker.PickRandom(new List<string>() { "DEBIT", "CREDIT" }), 
                    faker.Random.String2(200)
                );
            }
        }
    }
}
