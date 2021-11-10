using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Services
{
    public class CustomerService
    {
        public static void Deposit(DataStorage DataStorage,string Bankname,string Username,Decimal Amount)
        {
            List<Bank> Bank = DataStorage.Bank;

            var test = Bank.Select(_ => _.Name.Equals(Bankname)).FirstOrDefault();

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == Bankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for(int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            Accounts[j].Amount += Amount;

                            List<Transactions> Transaction = Accounts[j].Transaction;

                            string BankId = Bank[i].ID;

                            string AccountId = Accounts[j].ID;

                            DateTime TransactionTime = DateTime.Now;

                            Transaction.Add(new Transactions(Bankname, Username, Bankname, Username, TransactionStatus.Deposited, TransactionTime, Amount, BankId, AccountId));

                            return;
                        }
                    }
                }
            }
        }

        public static Status Withdraw(DataStorage DataStorage,string Bankname,string Username,Decimal Amount)
        {
            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == Bankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            if (Accounts[j].Amount < Amount) return Status.InsufficientAmount;

                            Accounts[j].Amount -= Amount;

                            List<Transactions> Transaction = Accounts[j].Transaction;

                            string BankId = Bank[i].ID;

                            string AccountId = Accounts[j].ID;

                            DateTime TransactionTime = DateTime.Now;

                            Transaction.Add(new Transactions(Bankname, Username, Bankname, Username, TransactionStatus.Withdraw, TransactionTime, Amount, BankId, AccountId));

                            return Status.SufficientAmount;
                        }
                    }
                }
            }

            return Status.SufficientAmount;
        }

        public static Status Transfer(DataStorage DataStorage, string SenderBankname, string SenderUsername, string ReceiverBankname, string ReceiverUsername, Decimal Amount, string Mode)
        {
            decimal ReceivingAmount=0;

            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == SenderBankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for(int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == SenderUsername)
                        {
                            if (Accounts[j].Amount < Amount) return Status.InsufficientAmount;

                            if (Mode == "IMPS")
                            {
                                decimal IMPSCharge;

                                if (ReceiverBankname == SenderBankname)
                                {
                                    IMPSCharge = Bank[i].ImpsChargeForSameBank;
                                }
                                else
                                {
                                    IMPSCharge = Bank[i].ImpsChargeForDifferentBank;
                                }

                                IMPSCharge =(Amount * IMPSCharge) / 100;

                                ReceivingAmount = (Amount - IMPSCharge);

                                Accounts[j].Amount -= ReceivingAmount;
                            }
                            else if (Mode == "RTGS")
                            {
                                decimal RTGSCharge;

                                if (ReceiverBankname == SenderBankname)
                                {
                                    RTGSCharge = Bank[i].ImpsChargeForSameBank;
                                }
                                else
                                {
                                    RTGSCharge = Bank[i].ImpsChargeForDifferentBank;
                                }

                                RTGSCharge = (Amount * RTGSCharge) / 100;

                                ReceivingAmount = (Amount - RTGSCharge);

                                Accounts[j].Amount -= ReceivingAmount;
                            }

                            List<Transactions> Transactions = Accounts[j].Transaction;

                            string BankId = Bank[i].ID;

                            string AccountId = Accounts[j].ID;

                            Transactions.Add(new Transactions(SenderBankname, SenderUsername, ReceiverBankname, ReceiverUsername, TransactionStatus.Transfer, DateTime.Now, Amount, BankId, AccountId));
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

                            Accounts[j].Amount += ReceivingAmount;

                            string BankId = Bank[i].ID;

                            string AccountId = Accounts[j].ID;

                            Transactions.Add(new Transactions(SenderBankname, SenderUsername, ReceiverBankname, ReceiverUsername, TransactionStatus.Transfer, DateTime.Now, ReceivingAmount, BankId, AccountId));
                        }
                    }
                }
            }

            return Status.SufficientAmount;
        }

        public static void TransactionHistory(DataStorage DataStorage,string Bankname,string Username)
        {
            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == Bankname)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            List<Transactions> Transactions = Accounts[j].Transaction;

                            for (int k = 0; k < Transactions.Count; k++)
                            {

                                if (Transactions[k].TransactionStatus == TransactionStatus.Deposited)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " + TransactionStatus.Deposited + " into your account");

                                if (Transactions[k].TransactionStatus == TransactionStatus.Withdraw)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " + TransactionStatus.Withdraw + " from your account");

                                if (Transactions[k].TransactionStatus == TransactionStatus.Transfer)

                                    Console.WriteLine("Rs " + Transactions[k].Amount + " has been " + TransactionStatus.Transfer + "  from your account into " + Transactions[k].ReceiverUsername);
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}
