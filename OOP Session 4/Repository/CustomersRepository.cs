using OOP_Session_4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Repository
{
    internal class CustomersRepository : ICustomersRepository
    {
        public List<Customer> customers = [];

        public List<BankAccount> GetAllAccounts()
        {
            return customers.SelectMany(cust => cust.accounts).ToList();
        }

        public List<BankAccount> GetCustomerAccounts(Customer cust)
        {
            return cust.accounts;
        }

        public Customer? FindCustomerByNameOrNationalId(string query)
        {
            return customers.Find(cust => cust.fullName.Contains(query) || cust.nationalId.Contains(query));
        }

        public Customer? FindCustomerByNationalId(string query)
        {
            return customers.Find(cust => cust.nationalId.Contains(query));
        }

        public void AddCustomer(Customer cust)
        {
            customers.Add(cust);
        }

        public bool RemoveCustomerById(string nationalId)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].nationalId == nationalId)
                {
                    if (customers[i].GetTotalBalance() == 0)
                    {
                        customers.RemoveAt(i);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
