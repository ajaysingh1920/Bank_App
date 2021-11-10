using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Services
{
    public class StaffService
    {
        public static void CreateAccount(DataStorage DataStorage,string BankName,string Username,string Password)
        {
            List<Bank> Bank = DataStorage.Bank;

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    Accounts.Add(new Account(Username, Password));

                    return;
                   
                }
            }
        }

        public static void Delete(DataStorage DataStorage,string BankName,string Username)
        {
            List<Bank> Bank = DataStorage.Bank;

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for(int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            Accounts.RemoveAt(j);

                            return;
                        }
                    }
                }
            }
        }

        public static void ShowTransactionHistory(DataStorage DataStorage,string Bankname,string Username)
        {
            List<Bank> Bank = DataStorage.Bank;

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == Bankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for(int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            List<Transactions> Transactions = Accounts[j].Transaction;

                            for(int k = 0; k < Transactions.Count; k++) {

                                if(Transactions[k].TransactionStatus==TransactionStatus.Deposited)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " +  TransactionStatus.Deposited + " into your account");

                                if(Transactions[k].TransactionStatus==TransactionStatus.Withdraw)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " + TransactionStatus.Withdraw + " from your account");

                                if (Transactions[k].TransactionStatus == TransactionStatus.Transfer)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " + TransactionStatus.Transfer + "  from your account into " + Transactions[k].ReceiverUsername);
                            }
                            return ;
                        }
                    } 
                }
            }
        }


        public static void  RevertTransaction(DataStorage DataStorage,string Bankname,string Username)
        {
            string ReceiverBankname="@";

            string ReceiverUsername="@";

            Decimal TransferAmount=0;

            List<Bank> Bank = DataStorage.Bank;

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == Bankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            List<Transactions> Transactions = Accounts[j].Transaction;

                            for(int k = Transactions.Count - 1; k >= 0; k--)
                            {
                                if (Transactions[k].TransactionStatus == TransactionStatus.Transfer && Transactions[k].SenderUsername==Username)
                                {
                                    ReceiverBankname = Transactions[k].ReceiverBankname;

                                    ReceiverUsername = Transactions[k].ReceiverUsername;

                                    TransferAmount = Transactions[k].Amount;

                                    Accounts[j].Amount += TransferAmount;

                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == ReceiverBankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == ReceiverUsername)
                        {
                            List<Transactions> Transactions = Accounts[j].Transaction;

                            for (int k = Transactions.Count - 1; k >= 0; k--)
                            {
                                if (Transactions[k].TransactionStatus == TransactionStatus.Transfer && Transactions[k].ReceiverUsername==ReceiverUsername)
                                {
                                    Accounts[j].Amount -= TransferAmount;
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
