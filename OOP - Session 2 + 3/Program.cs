namespace DEPI_tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount defaultAccount = new();
            BankAccount shalabyAccount = new("Shalaby","38560076101121","01003496746","Lolz",15);
            defaultAccount.ShowAccountDetails();
            shalabyAccount.ShowAccountDetails();

            List<BankAccount> accounts = new();
            SavingAccount acc1 = new("Hammoud", "324600761089621", "01003296786", "Cairo", 100, 0.15m);
            CurrentAccount acc2 = new("Mohamed", "124200761589421", "01233256786", "Cairo", 150, 1000m);
            accounts.Add(acc1);
            accounts.Add(acc2);

            foreach (BankAccount acc in accounts)
            {
                acc.ShowAccountDetails();
            }
            acc1.CalculateInterest();
        }
    }
}
