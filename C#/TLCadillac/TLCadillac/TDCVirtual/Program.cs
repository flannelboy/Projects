namespace TLCadillac
{
    class TestClass
    {
        public class Budget
        {
            //DECLARING NEW PARAMETERS
            public double _apr;
            public double _rp;
            public double _term;
            public double _tax;
            public virtual double InterestAmount() => 0;
            public virtual double TaxAmount() => 0;
            public virtual double FinanceAmount() => 0;
            public virtual double MonthlyAmount() => 0;
            public virtual double PayFullAmount() => 0;
        }
        public class FinanceBudget : Budget
        {
            public FinanceBudget(double apr, double retail, double term, double tax)
            {
                _apr = apr;
                _rp = retail;
                _term = term;
                _tax = tax;
            }
            //OVERRIDING
            public override double InterestAmount() => (PayFullAmount() * (_apr / (_term*12)));
            public override double TaxAmount() => _rp * _tax;
            public override double FinanceAmount() => _rp + (InterestAmount()*(_term * 12)) + TaxAmount();
            public override double MonthlyAmount() => FinanceAmount() / (_term * 12);
            //public override double PayFullAmount() => _rp + (_rp * _tax);

            static void Main()
            {
                Budget budget1 = new Budget();

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
                budget1.PayFullAmount();

            }

        }

    }
}
