using System;
using System.Collections.Generic;
using System.Text;

namespace DEPI_tasks
{
    internal class SavingAccount : BankAccount
    {
        public decimal InterestRate;
        public override void ShowAccountDetails()
        {
            Console.WriteLine($"Name: {FullName} - Phone: {PhoneNumber} - Balance: {Balance}EGP - Interest Rate: {InterestRate}");
        }

        public void CalculateInterest()
        {
            Console.WriteLine($"Interest: {InterestRate*(decimal)Balance}");
        }

        public SavingAccount(string fullName, string nationalID, string phoneNumber, string address, double balance, decimal interestRate) : base(fullName, nationalID, phoneNumber, address, balance)
        {
            InterestRate = interestRate;
        }
    }
}
