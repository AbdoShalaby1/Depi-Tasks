using OOP_Session_4.Models;
using OOP_Session_4.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Views
{
    internal class UserView
    {
        public static void Display(Customer cust, ICustomersRepository repo, ITransactionLogsRepository logs)
        {
            var active = DisplayAccounts.DisplayCustomerAccounts(cust);
            if (active is null)
            {
                return;
            }
            while (true)
            {

                Console.WriteLine("(1) Deposit, (2) Withdraw, (3) Transfer, (4) Show Balance, (5) Change Details, (6) Exit");
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    case '1':
                        Console.WriteLine("Deposit Amount: ");
                        int amount = int.Parse(Console.ReadLine());
                        active.Deposit(amount);
                        break;
                    case '2':
                        Console.WriteLine("Withdraw Amount: ");
                        amount = int.Parse(Console.ReadLine());
                        active.Withdraw(amount);
                        break;
                    case '3':
                        Console.WriteLine("Transfer Amount: ");
                        amount = int.Parse(Console.ReadLine());
                        BankAccount? acc = DisplayAccounts.DisplayAllAccounts(repo);
                        active.Transfer(acc, amount);
                        break;
                    case '4':
                        Console.WriteLine($"Balance: {active.Balance}");
                        break;
                    case '5':
                        
                    case '6':
                        return;

                }
            }

        }
    }
}
