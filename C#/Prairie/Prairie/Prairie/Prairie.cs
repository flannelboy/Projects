namespace Prairie
{
    public class Prairie
    {
        public Prairie()
        {
            Console.WriteLine("Welcome to Prarie!");
            Login();
        }

        public void Login()
        {


            Console.WriteLine("Username:"); var username = Console.ReadLine();
            Console.WriteLine("Password:"); var password = Console.ReadLine();
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {

            }

            if (username.Contains("t") && password.Contains("l"))
            {

                Console.WriteLine("Login success!");
                GetGreeting();
            }
            else
            {
                Console.WriteLine("Login failed.");
                Login();
            }
        }
        public void GetGreeting()
        {
            DateTime g = DateTime.Now; string greeting;
            if (g.Hour <= 12 && g.Hour >= 5)
            {
                greeting = "Good morning ";
            }
            else if (g.Hour >= 12)
            {
                greeting = "Good afternoon ";
            }
            else if (g.Hour >= 16)
            {
                greeting = "Good evening ";
            }
            else
            {
                greeting = "Good night ";
            }

            Console.WriteLine(greeting + "Tien! How can I help?");
            GetDashboard();
        }
        public void GetDashboard()
        {
            var a = Convert.ToString(Console.ReadLine());            
            switch (a.ToLower())
            {
                case "todo": GetTodo(); break;              
                default: Console.WriteLine("I didn't understand that, try again:"); GetDashboard(); break;
            }
        }
        public void GetTodo()
        {
            Console.WriteLine("Current todo list:");
            
                          
                Console.WriteLine("Do you want to add more?");
                var a = Convert.ToString(Console.ReadLine());
                if (a.ToLower() == "yes")
                {
                    Console.WriteLine("What do you have to do?");
                    var title = Convert.ToString(Console.ReadLine());
                }
                else if (a.ToLower() == "no")
                {
                    ExitLobby();
                }
                else
                {
                    Console.WriteLine("I didn't understand that, try again.");
                    GetTodo();
                }
                
            


            ExitLobby();
        }
        

        public void ExitLobby()
        {
            Console.WriteLine("Thanks for using me today! Click [ESE] to exit.");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                new Prairie();
            }
            else
            {
                ExitLobby();
            }

        }
    }
}

