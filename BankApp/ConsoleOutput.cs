using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.cli
{
    public class ConsoleOutput
    {
        public static void WelcomeDisplay()
        {
            Console.WriteLine("WELCOME TO BANKING APPLICATION:");
        }

        public static void MainMenuDisplay()
        {
            Console.WriteLine("Customer->1");
            Console.WriteLine("Staff->2");
            Console.WriteLine("Quit->3");
        }

        public static void StaffOperationMenu()
        {
            Console.WriteLine("Create->1");
            Console.WriteLine("Delete->2");
            Console.WriteLine("TransactionHistory->3");
            Console.WriteLine("RevertTransaction->4");
            Console.WriteLine("ExchanceCurrency->5");
        }

        public static void CustomerOperationMenu()
        {
            Console.WriteLine("Deposit->1");
            Console.WriteLine("Withdraw->2");
            Console.WriteLine("Transfer->3");
            Console.WriteLine("TransactionHistory-4");
        }

        public static void EnterBankName()
        {
            Console.WriteLine("Please Enter the Bank Name:");
        }

        public static void EnterUsername()
        {
            Console.WriteLine("Please Enter the Username:");
        }

        public static void EnterPassword()
        {
            Console.WriteLine("Pleae Enter the Password");
        }

        public static void EnterTransferMode()
        {
            Console.WriteLine("RTGS->1");
            Console.WriteLine("IMPS->2");
        }
    }
}
