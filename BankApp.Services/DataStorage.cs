using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class DataStorage
    {
        public List<Bank> Bank;

        public DataStorage()
        {
            Bank = new List<Bank>();
            Bank.Add(new Bank("AAA"));
            AddStaff("AAA");
            Bank.Add(new Bank("BBB"));
            AddStaff("BBB");
            Bank.Add(new Bank("CCC"));
            AddStaff("CCC");
        }

        public void AddStaff(string BankName)
        {
            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    Bank[i].Staff.Add(new Staff("SSS", "@@@"));
                }
            }
        }
    }
}
