using OOP_Session_4.Models;
using OOP_Session_4.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_Session_4.Views
{
    internal class RegisterView
    {
        public static Customer? Display(ICustomersRepository repo)
        {
            Console.WriteLine("Full Name: ");
            string? name = Console.ReadLine();
            Console.WriteLine("National ID (14 Chars): ");
            string? nationalId = Console.ReadLine();
            Console.WriteLine("Date of birth (ex: 27-10-2005): ");
            string? dob = Console.ReadLine();

            try
            {
                Customer cust = new(name, nationalId, DateOnly.ParseExact(
                    dob,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture
                ));
                repo.AddCustomer(cust);
                Console.WriteLine("Added!");
                return cust;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Data");
            }
            return null;


        }
    }
}
