namespace TLCadillac
{
    //ABSTRACT CLASS
    public abstract class FinalPrice
    {
        public abstract double GetFinalPrice();
        public void ThisIsAMessage()
        {
            Console.WriteLine("This is a message");
        }
    }
    public class Calculator : FinalPrice
    {
        public double _rp;
        public Calculator(int r) => _rp = r;
        public override double GetFinalPrice() => _rp + ((_rp *6.25)/100);
        static void Main()
        {
            var fp  = new Calculator(37295);
            Console.WriteLine($"Your expected price to pay is ${fp.GetFinalPrice()}"); 
        }
    }
}

