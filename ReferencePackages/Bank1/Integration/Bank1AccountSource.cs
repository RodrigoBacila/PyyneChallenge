namespace Bank1.Integration
{
    /**
    * Created by Par Renyard on 5/12/21.
    */
    public class Bank1AccountSource
    {
        public double GetAccountBalance(long accountId)
        {
            return 215.5d;
        }

        public string GetAccountCurrency(long accountId)
        {
            return "USD";
        }

        public List<Bank1Transaction> GetTransactions(long accountId, DateTime fromDate, DateTime toDate)
        {
            return new List<Bank1Transaction>() {
                    new Bank1Transaction(100d, Bank1Transaction.TYPE_CREDIT, "Check deposit"),
                    new Bank1Transaction(25.5d, Bank1Transaction.TYPE_DEBIT, "Debit card purchase"),
                    new Bank1Transaction(225d, Bank1Transaction.TYPE_DEBIT, "Rent payment")
            };
        }
    }
}