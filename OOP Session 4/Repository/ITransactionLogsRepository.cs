using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Session_4.Repository
{
    internal interface ITransactionLogsRepository
    {
        public void DisplayLogs();
        public void Log();
    }
}
