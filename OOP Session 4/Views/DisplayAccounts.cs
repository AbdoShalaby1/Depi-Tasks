using OOP_Session_4.Models;
using OOP_Session_4.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Views
{
    internal class DisplayAccounts
    {
        public static BankAccount? DisplayCustomerAccounts(Customer cust)
        {
            Console.WriteLine("Select Account: ");
            for (int i = 1; i <= cust.accounts.Count; i++)
            {
                Console.WriteLine($"({i}) ID: {cust.accounts[i - 1].AccountNumber} - Balance: {cust.accounts[i - 1].Balance} EGP");
            }
            Console.WriteLine($"({cust.accounts.Count + 1}) Create New Account");
            int ans = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            if (ans <= cust.accounts.Count)
            {
                return cust.accounts[ans - 1];
            }
            else if (ans == cust.accounts.Count + 1)
            {
                Console.WriteLine("(1) Standard - (2) Savings - (3) Current");
                char opt = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (opt)
                {
                    case '1':
                        var acc = new BankAccount(0);
                        cust.accounts.Add(acc);
                        Console.WriteLine("Added");
                        return acc;

                    case '2':
                        acc = new SavingsAccount(0.15, 0);
                        cust.accounts.Add(acc);
                        Console.WriteLine("Added");
                        return acc;

                    case '3':
                        acc = new CurrentAccount(2000, 0);
                        cust.accounts.Add(acc);
                        Console.WriteLine("Added");
                        return acc;
                }
            }
            return null;
        }

        public static BankAccount? DisplayAllAccounts(ICustomersRepository repo)
        {
            var accounts = repo.GetAllAccounts();
            Console.WriteLine("Select Account: ");
            for (int i = 1; i <= accounts.Count; i++)
            {
                Console.WriteLine($"({i}) ID: {accounts[i - 1].AccountNumber} - Balance: {accounts[i - 1].Balance} EGP");
            }
            int ans = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            if (ans <= accounts.Count)
            {
                return accounts[ans - 1];
            }
            return null;
        }
    }
}
