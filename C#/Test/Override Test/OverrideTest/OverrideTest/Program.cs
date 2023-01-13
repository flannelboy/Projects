namespace OverrideTest
{
    class TestClass
    {
        public class Computer
        {
            protected double _price;
            protected double _tax = 0.063;

            public Computer()
            {
            }

            public Computer(double price, double tax)
            {
                _price = price;
                _tax = tax;
            }

            public virtual double FinalCost()
            {
                return _price - (_price * _tax);
            }
        }

        public class Laptop : Computer
        {
            public Laptop(double price)
            {
            }

            public override double FinalCost()
            {
                return _price + (_price * _tax);
            }
        }

        public class PC : Computer
        {
            public PC(double price)
            {
            }

            public override double FinalCost()
            {
                return (_price + 100) + (_price * _tax);
            }
        }



        static void Main()
        {
            double price = 1000;
            Computer laptop = new Laptop(price);
            Computer pc = new PC(price);

            Console.WriteLine("Laptop cost $" + laptop.FinalCost());
            Console.WriteLine("PC cost $" + pc.FinalCost());
        }
    }
}