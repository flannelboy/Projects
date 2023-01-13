using BankTL.AccountCommand;
using BankTL.BankException;
using System.Text.Json;

namespace BankTL
{
    public class ManualBank : Bank
    {
        public override void Lobby()
        {
            {
                Console.WriteLine("Are you a current or new customer?"); var answer = Convert.ToString(Console.ReadLine());
                switch (answer.ToLower())
                {
                    case "current":
                        SecurityCheck();
                        break;
                    case "new":
                        Open();
                        break;
                    default:
                        Lobby();
                        break;
                }
            }
        }
        public override void SecurityCheck()
        {
            string inputUser; string inputPass;
            do
            {
                Console.WriteLine("Username: "); inputUser = Console.ReadLine();
                Console.WriteLine("Password: "); inputPass = Console.ReadLine();

                Account = Accounts.SingleOrDefault(a => a.Key == inputUser && a.Value.Password == inputPass).Value;

                if (Account != null)
                {
                    Console.WriteLine("Verification passed.");
                }
                else
                {
                    Console.WriteLine("Verification failed.");
                    Lobby();
                }
            }
            while (Account == null);
            Menu();
        }
        public override void Menu()
        {

            Console.WriteLine("How can I help you?"); string answer = Console.ReadLine();
            switch (answer.ToLower())
            {
                case "balance":
                    Balance();
                    break;
                case "deposit":
                    Deposit();
                    break;
                case "withdraw":
                    Withdraw();
                    break;
                case "no":
                    Lobby();
                    break;
                default:
                    break;
            }

            JsonSerializerOptions options = new() { WriteIndented = true };
            string accountData = JsonSerializer.Serialize(Accounts, options);
            File.WriteAllText("UserDB", accountData);
            //File.AppendAllText("UserDB", accountData);
            Menu();
        }

        public override void Open()
        {
            Console.WriteLine("Name:"); string name = Console.ReadLine();
            Console.WriteLine("Create a username:"); string username = Console.ReadLine();
            Console.WriteLine("Create a password:"); string password = Console.ReadLine();

            if (password == username)
            {
                do
                {
                    Console.WriteLine("Username and password can't be identical.");
                    Console.WriteLine("Create a username:"); username = Console.ReadLine();
                    Console.WriteLine("Create a password:"); password = Console.ReadLine();
                }
                while (password == username);
            }

            Account = new Account(name, username, password);
            Accounts.Add(Account.Username, Account);

            Console.WriteLine($"Account created successfully.");
            Menu();
        }
        public override void Balance()
        {
            Console.WriteLine("Current balance: $" + Account.Balance);

            foreach (Transaction t in Account.Transactions)
            {
                Console.WriteLine(t);
            }

        }
        public override void Deposit()
        {
            double amount = 0;
            Console.WriteLine("Enter amount:");

            Exception e = null;
            do
            {
                e = null;
                try
                {
                    amount = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Wrong input, try again.");
                    e = ex;
                }
            }
            while (e != null);

            IAccountCommand bankCommand = new DepositCommand();
            bankCommand.Execute(Account, amount);
            Console.WriteLine("Deposit amount: $" + amount); Console.WriteLine("New balance: $" + Account.Balance);
        }
        public override void Withdraw()
        {
            double amount = 0;

            Exception e = null;
            do
            {
                e = null;
                try
                {
                    Console.WriteLine("Enter amount:");
                    amount = Convert.ToDouble(Console.ReadLine());
                    IAccountCommand bankCommand = new WithdrawCommand();
                    bankCommand.Execute(Account, amount);
                }
                catch (FormatException ee)
                {
                    Console.WriteLine("Wrong input, try again.");
                    e = ee;
                }
                catch (InsufficientFundException ex)
                {
                    Console.WriteLine(ex.Message);
                    e = ex;
                }
            }
            while (e != null);

            Console.WriteLine("Withdraw amount: $" + amount); Console.WriteLine("New balance: $" + Account.Balance);
        }
    }
}
