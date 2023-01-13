using BankTL.AccountCommand;
using System.Text.Json;
using BankTL.BankException;
namespace BankTL
{
    public abstract class Bank
    {
        public Bank()
        {
            Console.WriteLine("Welcome to Bank of TL");
            string accounts = File.ReadAllText("UserDB");
            Accounts = JsonSerializer.Deserialize<Dictionary<string, Account>>(accounts);
            //Accounts = new Dictionary<string, Account>();
            Lobby();
        }
        //public List<Account> Accounts { get; set; }

        public Account Account { get; set; }
        public Dictionary<string, Account> Accounts { get; set; }
        public abstract void Lobby();
        public abstract void SecurityCheck();
        public abstract void Menu();
        public abstract void Open();
        public abstract void Balance();
        public abstract void Deposit();
        public abstract void Withdraw();
    }
}





