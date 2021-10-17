using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.cli
{
    public class StandardMessages
    {
        public static void Welcome()
        {
            Console.WriteLine("WELCOME TO BANKING APPLICATION:");
        }

        public static void ChoiceDisplay()
        {
            Console.WriteLine("Create->0");
            Console.WriteLine("Deposit->1");
            Console.WriteLine("WithDraw->2");
            Console.WriteLine("Transfer->3");
            Console.WriteLine("TransactionHistory->4");
            Console.WriteLine("Quit->5");
        }

        public static void EnterBankName()
        {
            Console.WriteLine("Please enter the bank name");
        }

        public static void EnterName()
        {
            Console.WriteLine("Enter your name");
        }

        public static void EnterPassword()
        {
            Console.WriteLine("Enter password");
        }

        public static void EnterAmount()
        {
            Console.WriteLine("Please enter the amount");
        }
    }
}
