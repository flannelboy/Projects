namespace BankTL
{
    public class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "a":
                    new AutoBank();
                    break;
                case "m":
                    new ManualBank();
                    break;
            }
        }
    }
}

