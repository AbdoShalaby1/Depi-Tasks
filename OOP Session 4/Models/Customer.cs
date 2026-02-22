using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Models
{
    internal class Customer(string fullName, string nationalId, DateOnly dateOfBirth)
    {
        public string id = Guid.NewGuid().ToString(); // uuid
        public string fullName = fullName;
        public string nationalId = nationalId;
        public DateOnly dateOfBirth = dateOfBirth;
        public List<BankAccount> accounts = [];

        public void UpdateCustomerName(string name)
        {
            this.fullName = name;
        }
        public void UpdateCustomerDOB(DateOnly date)
        {
            this.dateOfBirth = date;
        }

        public double GetTotalBalance()
        {
            return accounts.Sum(x => x.Balance);
        }


    }
}
