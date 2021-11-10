using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        public string ID;

        public string Username { get; set; }

        public string Password { get; set; }

        public decimal Amount { get; set; }

        public List<Transactions> Transaction { get; set; }

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Transaction = new List<Transactions>();
            var dt = DateTime.Now;
            this.ID = Username.Substring(0, 4) + dt.ToString("MMMM dd") + " " + dt.ToString("HH:mm:ss");
        }
    }
}
