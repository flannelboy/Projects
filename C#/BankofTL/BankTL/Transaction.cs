namespace BankTL
{
    public class Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public double Balance { get; internal set; }

        public Transaction(double amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
        //data to string
        public override String ToString()
        {
            return $"Date: {Date.ToShortDateString()}\tAmount: ${Amount}\tBalance: ${Balance}";
        }
    }
}
