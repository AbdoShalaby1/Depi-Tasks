using System;
using System.Collections.Generic;
using System.Text;

namespace DEPI_tasks
{
    internal class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit;
        public override void ShowAccountDetails()
        {
            Console.WriteLine($"Name: {FullName} - Phone: {PhoneNumber} - Balance: {Balance}EGP - Overdraft Limit: {OverdraftLimit}");
        }

        public CurrentAccount(string fullName, string nationalID, string phoneNumber, string address, double balance, decimal overdraftLimit) : base(fullName, nationalID, phoneNumber, address, balance)
        {
            OverdraftLimit = overdraftLimit;
        }


    }
}
