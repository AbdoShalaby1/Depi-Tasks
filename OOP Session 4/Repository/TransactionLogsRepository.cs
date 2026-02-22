using OOP_Session_4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Repository
{
    internal class TransactionLogsRepository : ITransactionLogsRepository
    {
        public List<LogItem> logs = [];

        public void DisplayLogs()
        {
            foreach (var log in logs)
            {
                // Basic info used for every log
                string output = $"{log.dateTime:G} | {log.type} | Account: {log.account.AccountNumber}";

                // The condition: if SentTo is NOT null, append the "To" field
                if (log.sentTo != null)
                {
                    output += $" | Sent To: {log.sentTo.AccountNumber}";
                }

                Console.WriteLine(output);
            }
        }

        public void Log()
        {
            
        }
    }
}
