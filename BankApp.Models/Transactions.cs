using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Transactions
    {
        public TransactionStatus transactionStatus;

        public DateTime on;

        public Decimal amount;

        public Transactions(TransactionStatus transactionStatus, DateTime on, Decimal amount)
        {
            this.transactionStatus = transactionStatus;
            this.on = on;
            this.amount = amount;
        }
    }
}
