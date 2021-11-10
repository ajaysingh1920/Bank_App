using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class InputValidator
    {
        
        public static Status ValidateBankName(DataStorage DataStorage,string BankName)
        {
            List<Bank> Bank = DataStorage.Bank;
      
            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName) return Status.BankNameValid;
            }
            return Status.BankNameInvalid;
        }

        public static Status ValidateStaffUsername(DataStorage DataStorage,string BankName,string Username)
        {
            List<Bank> Bank = DataStorage.Bank;

            for(int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Staff> Staff = Bank[i].Staff;

                    for(int j = 0; j < Staff.Count; j++)
                    {
                        if (Staff[j].Username == Username) return Status.UsernameValid;
                    }
                }
            }

            return Status.UsernameInvalid;
        }
        
        public static Status ValidateStaffPassword(DataStorage DataStorage,string BankName,string Username,string Password)
        {
            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Staff> Staff = Bank[i].Staff;

                    for (int j = 0; j < Staff.Count; j++)
                    {
                        if (Staff[j].Username == Username)
                        {
                            if (Staff[j].Password == Password) return Status.PasswordValid;
                        }
                    }
                }
            }
            return Status.PasswordInvalid;
        }

        public static Status ValidateAccountUsername(DataStorage DataStorage,string BankName,string Username)
        {
            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username) return Status.UsernameValid;
                    }
                }
            }

            return Status.UsernameInvalid;
        }

        public static Status ValidateAccountPassword(DataStorage DataStorage,string BankName,string Username,string Password)
        {
            List<Bank> Bank = DataStorage.Bank;

            for (int i = 0; i < Bank.Count; i++)
            {
                if (Bank[i].Name == BankName)
                {
                    List<Account> Accounts = Bank[i].Accounts;

                    for (int j = 0; j < Accounts.Count; j++)
                    {
                        if (Accounts[j].Username == Username)
                        {
                            if (Accounts[j].Password == Password) return Status.PasswordValid;
                        }
                    }
                }
            }
            return Status.PasswordInvalid;
        }
    }
}
