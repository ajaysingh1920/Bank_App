using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        public string username { get; set; }

        public string password { get; set; }

        public decimal amount { get; set; }

        public List<Transactions> transaction { get; set; }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
            transaction = new List<Transactions>();
        }
    }
}
