using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Bank
    {
        public string ID;

        public string Name;

        public int RtgsChagrgeForSameBank;

        public int ImpsChargeForSameBank;

        public int RtgsChargeForDifferentBank;

        public int ImpsChargeForDifferentBank;

        public List<Account> Accounts;

        public List<Staff> Staff;

        public Bank(string name)
        {
            this.Name = name;
            this.Accounts = new List<Account>();
            this.Staff = new List<Staff>();
            this.RtgsChagrgeForSameBank = 0;
            this.ImpsChargeForSameBank = 5;
            this.RtgsChagrgeForSameBank = 2;
            this.ImpsChargeForSameBank = 6;
            var dt = DateTime.Now;
            this.ID =name+ dt.ToString("MMMM dd") + " " + dt.ToString("HH:mm:ss");
        }
    }
} 
