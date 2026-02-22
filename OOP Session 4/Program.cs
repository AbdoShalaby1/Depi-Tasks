using OOP_Session_4.Models;
using OOP_Session_4.Repository;
using OOP_Session_4.Views;
using OOP_Session_4.Views;

namespace OOP_Session_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new CustomersRepository();
            var logs = new TransactionLogsRepository();
            Customer? curr = null;
            while (true)
            {
                char option;
                Console.WriteLine("Welcome to our modest bank!");
 
                Console.WriteLine("(1) Login, (2) Register");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                switch (option)
                {
                    case '1':
                        curr = LoginView.Display(context);
                        break;
                    case '2':
                        curr = RegisterView.Display(context);
                        break;
                    default:
                        Console.WriteLine("Invalid!");
                        break;
                }
                if (curr == null)
                    continue;

                UserView.Display(curr!, context);

            }
            
        }
    }
}
