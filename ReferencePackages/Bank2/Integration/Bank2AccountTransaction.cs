namespace Bank2.Integration
{
    /**
     * Created by Par Renyard on 5/12/21.
     */
    public class Bank2AccountTransaction
    {
        public enum TRANSACTION_TYPES
        {
            DEBIT, CREDIT
        }

        private readonly double amount;
        private readonly TRANSACTION_TYPES type;
        private readonly string text;

        public Bank2AccountTransaction(double amount, TRANSACTION_TYPES type, string text)
        {
            this.amount = amount;
            this.type = type;
            this.text = text;
        }

        public double GetAmount()
        {
            return amount;
        }

        public new TRANSACTION_TYPES GetType()
        {
            return type;
        }

        public string GetText()
        {
            return text;
        }
    }
}
