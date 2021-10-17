using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Bank
    {
        public string name { get; set; }

        public List<Account> accounts { get; set; }

        public Bank(string name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }
    }
}
