using OOP_Session_4.Models;

namespace OOP_Session_4.Repository
{
    internal interface ICustomersRepository
    {
        Customer? FindCustomerByNameOrNationalId(string query);
        Customer? FindCustomerByNationalId(string query);
        List<BankAccount> GetAllAccounts();
        List<BankAccount> GetCustomerAccounts(Customer cust);
        void AddCustomer(Customer cust);
    }
}