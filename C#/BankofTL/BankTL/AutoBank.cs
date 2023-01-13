using BankTL.AccountCommand;

namespace BankTL
{
    public class AutoBank : Bank
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
            //Console.WriteLine("How can I help you?"); string answer = Console.ReadLine();
            //switch (answer.ToLower())
            //{
            //    case "balance":
            //        Balance();
            //        break;

            //    case "deposit":
            //        Deposit();
            //        break;
            //    case "withdraw":
            //        Withdraw();
            //        break;
            //    case "no":
            //        Lobby();
            //        break;
            //    default:
            //        Menu();
            //        break;
            //}

            Random random = new Random(); int randomNumber = random.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    Balance();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    Lobby();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        public override void Open()
        {
            Console.WriteLine("Enter your name:"); var name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Create a username:"); var username = Console.ReadLine();
            Console.WriteLine("Create a password:"); var password = Console.ReadLine();
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
            Accounts.Add(Account.Username,Account);
            Console.WriteLine($"Account created successfully.");
            Menu();
        }
        public override void Balance()
        {
            Console.WriteLine("Current balance: $" + Account.Balance);
            if (Account.Transactions.Count == 0)
            {
                Console.WriteLine("No transaction founded");
            }
            else
            {
                foreach (Transaction t in Account.Transactions)
                {
                    Console.WriteLine(t);
                }
            }
            Menu();
        }
        public override void Deposit()
        {
            Random random = new Random();
            double amount = random.Next(1, 999);

            IAccountCommand accountCommand = new DepositCommand();

            accountCommand.Execute(Account, amount);

            Console.WriteLine("Deposit amount: $" + amount); Console.WriteLine("New balance: $" + Account.Balance);

            Menu();
        }
        public override void Withdraw()
        {
            Random random = new Random();
            double amount = random.Next(1, 999);

            IAccountCommand accountCommand = new WithdrawCommand();

            Exception e = null;
            do
            {
                try
                {
                    e = null;
                    accountCommand.Execute(Account, amount);
                }
                catch (Exception ex)
                {
                    e = ex;

                    if (amount < Account.Balance)
                    {
                        Console.WriteLine("Not enough fund.");
                    }
                    else
                    {
                        Console.WriteLine("Withdraw amount: $" + amount);
                    }
                }
            }
            while (e == null);
            Console.WriteLine("New balance: $" + Account.Balance);
            Menu();
        }
    }
}
