using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Models
{
    internal class BankAccount
    {
        private int accountNumber;
        private double balance;
        public DateOnly dateOpened;
        static private int newAccountNumber = 0;
        public int AccountNumber => accountNumber;
        public double Balance => balance;

        public BankAccount(double balance)
        {
            this.accountNumber = newAccountNumber;
            newAccountNumber++;
            this.balance = balance;
            this.dateOpened = DateOnly.FromDateTime(DateTime.Now);
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                this.balance += amount;
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Invalid Amount");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= this.balance)
            {
                this.balance -= amount;
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Invalid Amount");
            }
        }
        public void Transfer(BankAccount acc, double amount)
        {
            if (amount > 0 && amount <= this.balance)
            {
                this.balance -= amount;
                acc.balance += amount;
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Invalid Amount");
            }
        }

    }
}
