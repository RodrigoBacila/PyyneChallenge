namespace Bank1.Integration
{
    /**
    * Created by Par Renyard on 5/12/21.
    */
    public class Bank1Transaction
    {
        public static int TYPE_CREDIT = 1;
        public static int TYPE_DEBIT = 2;

        private readonly double amount;
        private readonly int type;
        private readonly string text;

        public Bank1Transaction(double amount, int type, string text)
        {
            this.amount = amount;
            this.type = type;
            this.text = text;
        }

        public double GetAmount()
        {
            return amount;
        }

        public new int GetType()
        {
            return type;
        }

        public string GetText()
        {
            return text;
        }
    }
}