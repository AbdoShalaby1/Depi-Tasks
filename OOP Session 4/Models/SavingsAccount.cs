using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Models
{
    internal class SavingsAccount : BankAccount
    {
        private double _interestRate;
        public SavingsAccount(double interest, double balance) : base(balance)
        {
            this._interestRate = interest;
        }

        public double CalculateInterest()
        {
            return _interestRate * Balance;
        }
    }
}
