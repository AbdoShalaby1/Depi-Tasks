using OOP_Session_4.Models;
using OOP_Session_4.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Views
{
    internal class LoginView
    {
        public static Customer? Display(ICustomersRepository customers)
        {
            Console.WriteLine("National ID: ");
            string? input = Console.ReadLine();
            Console.WriteLine();
            Customer? curr = customers.FindCustomerByNationalId(input);
            if (curr == null)
            {
                Console.WriteLine("Invalid");
                return null;
            }
            return curr;
        }
    }
}
