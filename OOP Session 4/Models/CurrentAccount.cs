using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Models
{
    internal class CurrentAccount : BankAccount
    {
        private double _overdraftLimit;
        public CurrentAccount(double overdraft, double balance) : base(balance)
        {
            this._overdraftLimit = overdraft;
        }

    }
}
