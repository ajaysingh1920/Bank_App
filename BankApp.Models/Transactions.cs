using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Transactions
    {
        public string Id;

        public TransactionStatus TransactionStatus;

        public DateTime TransactionTime;

        public string SenderBankname;

        public string SenderUsername;

        public string ReceiverBankname;

        public string ReceiverUsername;

        public Decimal Amount;

        public Transactions(string SenderBankname,string SenderUsername,string ReceiverBankname,string ReceiverUsername,TransactionStatus TransactionStatus, DateTime TransactionTIme, Decimal Amount,string BankId,string AccountId)
        {
            this.SenderBankname = SenderBankname;
            this.SenderUsername = SenderUsername;
            this.ReceiverBankname = ReceiverBankname;
            this.ReceiverUsername = ReceiverUsername;
            this.TransactionStatus = TransactionStatus;
            this.TransactionTime = TransactionTIme;
            this.Amount = Amount;
            var dt = DateTime.Now;
            this.Id = "TXN" + BankId + AccountId + dt.ToString("MMMMdd") + "" + dt.ToString("HH:mm:ss");
        }
    }
}
