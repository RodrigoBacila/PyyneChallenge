namespace Bank2.Integration
{
    /**
     * Created by Par Renyard on 5/12/21.
     */
    public class Bank2AccountBalance
    {

        private readonly double balance;
        private readonly string currency;

        public Bank2AccountBalance(double balance, string currency)
        {
            this.balance = balance;
            this.currency = currency;
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetCurrency()
        {
            return currency;
        }
    }
}
