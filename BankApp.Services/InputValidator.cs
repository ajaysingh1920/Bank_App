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
        public bool UsernameCheck(string bankname, string username, CreateService cs)
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
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public bool PasswordCheck(string bankname, string username, string password, CreateService cs)
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
                            if (list[j].password == password)
                            {
                                return true;
                            }
                        }
                    }

                }
            }

            return false;
        }

        public bool CheckBank(String bankname, CreateService cs)
        {
            for (int i = 0; i < cs.bank.Count; i++)
            {
                if (cs.bank[i].name == bankname)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
