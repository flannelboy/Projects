using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clocker.ClockCommand;


namespace Clocker
{
    public class Clocker
    {
        public void Lobby()
        {
            Console.WriteLine("Current or new employee?"); string a = Convert.ToString(Console.ReadLine());
            switch(a.ToLower())
            {
                case "current":
                    SignIn();
                    break;
                case "new":
                    Create();
                    break;
                default:
                    Lobby();
                    break;
            }
        }
        public void SignIn()
        {
            Console.WriteLine("Employee ID:"); string eID = Console.ReadLine();
            Console.WriteLine("Employee PIN:"); string ePIN = Console.ReadLine();
            Menu();
        }
        public void Create()
        {
            
            Console.WriteLine("Enter your name:");  string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Create employee ID:"); int eID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Create employee PIN:"); int ePIN = Convert.ToInt32(Console.ReadLine());
            decimal hour = 0;
            var employee = new Employee(name, eID, hour,ePIN);
            
            Menu();

        }
        public void Menu()
        {
            Console.WriteLine("What do you want to do?"); string answer = Convert.ToString(Console.ReadLine());
            
            switch(answer.ToLower())
            {
                case "clockin" or "clock in":
                    ClockIn();
                    break;
                case "clockout" or "clock out":
                    ClockOut();
                    break;
                case "check" or "check balance":
                    Balance();
                    break;
                default:
                    Menu();
                    break;
            }
           
        }
        public void Balance()
        {
            Console.WriteLine();
            Menu();

        }
        public void ClockIn()
        {
            decimal i = Convert.ToDecimal(Console.ReadLine());
            IClockerCommand clockerCommand = new ClockInCommand();
            clockerCommand.Execute( i);
            Menu();

        }
        public void ClockOut()
        {
            decimal i = Convert.ToDecimal(Console.ReadLine());
            var time = new Time(i);
            Menu();
        }
    }
}
