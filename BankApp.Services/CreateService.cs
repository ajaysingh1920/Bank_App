using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class CreateService
    {
        public List<Bank> bank;
        public CreateService()
        {
            bank = new List<Bank>();
        }

        public string CreateBank(String bankname)
        {
            for (int i = 0; i < bank.Count; i++)
            {
                if (bank[i].name == bankname)
                {
                    return bank[i].name;
                }
            }

            bank.Add(new Bank(bankname));
            return bankname;
        }

        public void CreateAccount(string bankname, string username, String password)
        {

            Account account = new Account(username, password);
            for (int i = 0; i < bank.Count; i++)
            {
                if (bank[i].name == bankname)
                {
                    bank[i].accounts.Add(account);
                }
            }
        }
    }
}
