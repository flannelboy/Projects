namespace DealerTL
{
    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Enter car's retail price:"); double retail = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter APR:"); double apr = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter car's sale tax:"); double tax = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter financing term (year):"); double term = Convert.ToDouble(Console.ReadLine());

            var p = new FinanceBudget(apr, retail, term, tax);

            Console.WriteLine($"Interest (monthly): ${p.InterestAmount()}");
            Console.WriteLine($"Tax: ${p.TaxAmount()}");
            Console.WriteLine($"Finance amount: ${p.FinanceAmount()}");
            Console.WriteLine($"Monthly payment amount: $ {p.MonthlyAmount()}");
            Console.WriteLine($"Pay in full amount: ${p.PayFullAmount()}");
            

        }

    }

}
