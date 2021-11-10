using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Staff
    {
        public string Id;

        public string Username;

        public string Password;

        public Staff(string Username,string Password)
        {
            this.Username = Username;
            this.Password = Password;
            var dt = DateTime.Now;
            this.Id = Username + dt.ToString("MMMM dd") + " " + dt.ToString("HH:mm:ss");
        }
    }
}
