using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqtest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9,10};


            var numbersLessThan6 = numbers.TakeWhile(n => n <6).Take(7);

            Console.WriteLine("Numbers that are less than 6:");

            foreach (int number in numbersLessThan6)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("8 number less than 10: ");
            var numbersLessThan10 = numbers.TakeWhile(n => n <10);
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

    }
}