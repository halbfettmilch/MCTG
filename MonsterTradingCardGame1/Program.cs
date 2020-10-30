using System;

namespace MonsterTradingCardGame1
{   
    class Program
    {
        User CreateUser()
        {
            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("User created:\n");
            User newUser = new User(username, password, email);
            Console.WriteLine("Username: {0} \nPassword: {1} \nEmail: {2} \n", newUser._Username, newUser._Password, newUser._Email);
            return newUser;
        }

        static void Main(string[] args)
        {
            
            
            string input = "y";
            while (input != "q")
            {
                Console.WriteLine("choose a command");
                Console.WriteLine("u: create new User");
                Console.WriteLine("q: Quit the program");

                input = Console.ReadLine();
                if(input == "u")
                {   
                    
                }

            }
            
        }
    }
}
