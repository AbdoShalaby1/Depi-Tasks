using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Models
{
    internal class LogItem(string type, DateTime dateTime, BankAccount account, BankAccount? sentTo = null)
    {
        public string type = type;
        public DateTime dateTime = dateTime;
        public BankAccount account = account;
        public BankAccount? sentTo = sentTo;

    }
}
