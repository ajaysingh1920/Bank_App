using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
   public class OperationsService
    {
        public void Deposit(string bankname, string username, decimal amount, CreateService cs)
        {
            for (int i = 0; i < cs.bank.Count; i++)
            {
                if (cs.bank[i].name == bankname)
                {
                    List<Account> list = cs.bank[i].accounts;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].username == username)
                        {
                            list[j].amount += amount;

                            list[j].transaction.Add(new Transactions(TransactionStatus.Credited, DateTime.Now, amount));
                        }
                    }
                }
            }
        }

        public void WithDraw(string bankname, string username, decimal amount, CreateService cs)
        {
            for (int i = 0; i < cs.bank.Count; i++)
            {
                if (cs.bank[i].name == bankname)
                {
                    List<Account> list = cs.bank[i].accounts;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].username == username)
                        {
                            list[j].amount -= amount;

                            list[j].transaction.Add(new Transactions(TransactionStatus.Debited, DateTime.Now, amount));
                        }
                    }
                }
            }
        }


        public void Transfer(string bankname, string username, string transferusername, CreateService cs, decimal amount)
        {
            for (int i = 0; i < cs.bank.Count; i++)
            {
                if (cs.bank[i].name == bankname)
                {
                    List<Account> list = cs.bank[i].accounts;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].username == username)
                        {
                            list[j].amount -= amount;

                            list[j].transaction.Add(new Transactions(TransactionStatus.Debited, DateTime.Now, amount));
                        }

                        if (list[j].username == transferusername)
                        {
                            list[j].amount += amount;

                            list[j].transaction.Add(new Transactions(TransactionStatus.Credited, DateTime.Now, amount));
                        }
                    }
                }
            }
        }

        public void TransactionHistory(string bankname, string username, CreateService cs)
        {
            for (int i = 0; i < cs.bank.Count; i++)
            {
                if (cs.bank[i].name == bankname)
                {
                    List<Account> list = cs.bank[i].accounts;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].username == username)
                        {
                            List<Transactions> transactionList = list[j].transaction;

                            for (int k = 0; k < transactionList.Count; k++)
                            {
                                Console.WriteLine("Rs " + transactionList[k].amount + " has been " + transactionList[k].transactionStatus + " on " + transactionList[k].on);
                            }
                        }
                    }
                }
            }
        }
    }
}
