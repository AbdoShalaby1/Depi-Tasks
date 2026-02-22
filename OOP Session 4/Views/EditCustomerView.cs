using OOP_Session_4.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OOP_Session_4.Views
{
    internal class EditCustomerView
    {
        public static void Display(Customer cust)
        {
            Console.WriteLine("(1) Name, (2) Date of Birth");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (input)
            {
                case '1':
                    Console.WriteLine("New Name: ");
                    cust.UpdateCustomerName(Console.ReadLine());
                    break;

                case '2':
                    Console.WriteLine("New Date Of Birth (ex: 27-10-2005): ");
                    
                    try
                    {
                        cust.UpdateCustomerDOB(DateOnly.ParseExact(
                        Console.ReadLine(),
                        "dd-MM-yyyy",
                        CultureInfo.InvariantCulture
                        ));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid!");
                    }
                    break;
            }

        }
    }
}
