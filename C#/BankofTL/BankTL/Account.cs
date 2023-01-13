using BankTL.BankException;

namespace BankTL
{
    public class Account
    {

        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public double Balance { get { return _balance; } }
        private double _balance;
        public int AccountNumber { get; }
        public List<Transaction> Transactions { get; }

        public Guid Key { get; set; }

        public Account(string name, string username, string password)
        {
            this.Password = password;
            this.Username = username;
            this.Name = name;
            Random accountNumb = new Random(1);
            AccountNumber = accountNumb.Next(1, 999999);
            _balance = 0;
            Transactions = new List<Transaction>();
            Key = Guid.NewGuid();
        }
        public void AddTransaction(Transaction transaction)
        {
            if (_balance + transaction.Amount < 0)
            {
                throw new InsufficientFundException();
            }
            _balance += transaction.Amount;

            transaction.Balance = _balance;
            Transactions.Add(transaction);
        }
    }
}
